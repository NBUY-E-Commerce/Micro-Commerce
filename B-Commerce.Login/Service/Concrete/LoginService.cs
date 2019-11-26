using B_Commerce.Common.Repository;
using B_Commerce.Login.Common;
using B_Commerce.Login.DomainClass;
using B_Commerce.Login.Request;
using B_Commerce.Login.Response;
using B_Commerce.Login.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using B_Commerce.Common.UOW;
using B_Commerce.Common.Security;

namespace B_Commerce.Login.Service.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        CacheManager _cacheManager;
        //Login service'in constructor'ında log nesneside olacak...
        public LoginService(IUnitOfWork unitOfWork, IRepository<User> userRepository, CacheManager cacheManager)
        {

            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _cacheManager = cacheManager;
        }

        public CheckTokenResponse CheckToken(string token)
        {

            User user = _cacheManager.GetUser(token);
            CheckTokenResponse checkTokenResponse = new CheckTokenResponse();

            if (user == null)
            {
                checkTokenResponse.SetStatus(Constants.ResponseCode.INVALID_TOKEN);
                return checkTokenResponse;
            }

            checkTokenResponse.SetStatus(Constants.ResponseCode.SUCCESS);
            checkTokenResponse.Username = user.Username;

            return checkTokenResponse;

        }

        private Token CreateToken(double expireDay = 1)
        {
            string token = RandomGenerator.Generate(45);
            return new Token
            {
                TokenText = token,
                EndDate = DateTime.Now.AddDays(expireDay),
            };
        }
        private AccountVerification CreateAccountVerificationCode()
        {
            string verificationCode = RandomGenerator.Generate(6);

            return new AccountVerification
            {
                VerificationCode = verificationCode,
                ExpireTime = DateTime.Now.AddDays(7),
            };
        }
        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                User _user = _userRepository.Get(t => (t.Email == loginRequest.Email || t.Phone == loginRequest.Phone)).FirstOrDefault();

                if (_user == null)
                {
                    loginResponse.SetStatus(Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD);
                    return loginResponse;
                }

                loginResponse.Username = _user.Username;

                if (_user.IsVerified == false)//farkili bir hata donmeli ki arayuzde  dogrulama sayfasina  atalim
                {
                    loginResponse.SetStatus(Constants.ResponseCode.FAILED);
                    return loginResponse;
                }

                if (_user.IsLocked && _user.LockedTime > DateTime.Now)
                {
                    loginResponse.SetStatus(Constants.ResponseCode.BANNED);
                    return loginResponse;
                }

                if (_user.IsLocked) { _user.IsLocked = false; _user.WrongCount = 0; }

                if (_user.Password != Cryptor.sha512encrypt(loginRequest.Password))
                {
                    _user.WrongCount++;
                    if (_user.WrongCount > 5) _user.UserLocked(1);

                    if (_unitOfWork.SaveChanges() > 0)
                    {
                        if (_user.IsLocked)
                        {
                            loginResponse.SetStatus(Constants.ResponseCode.BANNED);
                            return loginResponse;
                        }
                        else
                        {
                            loginResponse.SetStatus(Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD);
                            return loginResponse;
                        }
                    }
                    else
                    {
                        loginResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                        return loginResponse;
                    }
                }

                Token token = CreateToken();
                _user.WrongCount = 0;
                _user.Tokens.Add(token);

                if (_unitOfWork.SaveChanges() > 0)
                {
                    _cacheManager.AddUserToCache(token.TokenText, _user);

                    loginResponse.Username = _user.FullName();
                    loginResponse.Token = token.TokenText;
                    loginResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                    return loginResponse;
                }
            }
            catch (Exception)
            {
                loginResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                return loginResponse;
            }

            return loginResponse;
        }
        public RegisterResponse UserRegistry(User user)
        {
            RegisterResponse registerResponse = new RegisterResponse();

            try
            {
                if (_userRepository.Get(t => t.Email == user.Email).FirstOrDefault() != null)
                {
                    registerResponse.SetStatus(Constants.ResponseCode.EMAIL_IN_USE);
                    return registerResponse;
                }
                user.Password = Cryptor.sha512encrypt(user.Password);//şifreleme

                if (user.SocialInfos.Count == 0)
                {
                    user.AccountVerifications.Add(CreateAccountVerificationCode());
                }

                _userRepository.Add(user);

                if (_unitOfWork.SaveChanges() > 0)
                {
                    registerResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                    registerResponse.Username = user.Username;
                }
            }
            catch (Exception)
            {
                //mongodb log at.
                registerResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
            }

            return registerResponse;
        }

        public LoginResponse FacebookLogin(string fbcode)
        {
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                Facebook.FacebookClient fb = new Facebook.FacebookClient();
                dynamic result = fb.Post("oauth/access_token", new
                {
                    client_id = "3462488800442988",
                    client_secret = "2f5eb5daf3ea0fea4c09e729b1b379d7",
                    redirect_uri = "http://localhost:44318/FbLogin",//Test ederken localhost kısmını pcye göre değiştir.
                    code = fbcode
                });

                var accessToken = result.access_token;
                fb.AccessToken = accessToken;
                dynamic userinfo = fb.Get("me?fields=first_name,middle_name,last_name,id,email");

                string email = userinfo.email,
                    firstName = userinfo.first_name,
                    lastName = userinfo.last_name,
                    socialId = userinfo.id;

                User user = _userRepository.Get(t => t.Email == email).FirstOrDefault();

                if (user != null)
                {
                    try
                    {
                        Token token = CreateToken();
                        user.Tokens.Add(token);

                        if (_unitOfWork.SaveChanges() > 0)
                        {
                            _cacheManager.AddUserToCache(token.TokenText, user);

                            loginResponse.Username = user.FullName();
                            loginResponse.Token = token.TokenText;
                            loginResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                            return loginResponse;
                        }
                    }
                    catch (Exception)
                    {
                        loginResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                        return loginResponse;
                    }
                    return loginResponse;
                }

                user.Email = email;
                user.Name = firstName;
                user.Surname = lastName;
                user.SocialInfos.Add(new SocialInfo
                {
                    SocialID = socialId,
                    SocialType = new SocialType { SocialName = "Facebook" },
                    AccessToken = accessToken,
                });

                if (UserRegistry(user).Code == 0) // Başarılı register
                {
                    Token token = CreateToken();
                    user.Tokens.Add(token);
                    if (_unitOfWork.SaveChanges() > 0)
                    {
                        _cacheManager.AddUserToCache(token.TokenText, user);
                        loginResponse.Username = user.FullName();
                        loginResponse.Token = token.TokenText;
                        loginResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                        return loginResponse;
                    }

                }
                loginResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
            }
            catch
            {
                loginResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
            }
            return loginResponse;
        }

        public VerificationResponse CheckVerificationCode(int userID, string code)
        {
            User user = _userRepository.Get(t => t.ID == userID).FirstOrDefault();

            AccountVerification accountVerification = user.AccountVerifications.FirstOrDefault(t => t.VerificationCode == code);
            VerificationResponse verificationResponse = new VerificationResponse();

            if (accountVerification == null)
            {
                user.IsVerified = false;
                verificationResponse.SetStatus(Constants.ResponseCode.FAILED);
                return verificationResponse;
            }

            if (accountVerification.ExpireTime < DateTime.Now)
            {
                user.IsVerified = false;
                verificationResponse.SetStatus(Constants.ResponseCode.EXPIRED_CODE);
                return verificationResponse;
            }
            user.IsVerified = true;

            verificationResponse.SetStatus(Constants.ResponseCode.SUCCESS);


            return verificationResponse;
        }

    }
}
