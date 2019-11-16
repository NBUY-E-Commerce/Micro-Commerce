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
        private readonly IRepository<AccountVerification> _accountVerificationRepository;
        //Login service'in constructor'ında log nesneside olacak...
        public LoginService(IUnitOfWork unitOfWork, IRepository<User> userRepository, IRepository<AccountVerification> accountVerificationRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _accountVerificationRepository = accountVerificationRepository;
        }

        public CheckTokenResponse CheckToken(string token)
        {
            User user = CacheManager.GetUser(token);
            CheckTokenResponse checkTokenResponse = new CheckTokenResponse();

            if (user == null)
            {
                checkTokenResponse.SetError(Constants.ResponseCode.INVALID_TOKEN);
                return checkTokenResponse;
            }

            checkTokenResponse.SetError(Constants.ResponseCode.SUCCESS);
            checkTokenResponse.Username = user.Username;

            return checkTokenResponse;

        }

        private Token CreateToken(double expireDay = 1)
        {
            //Generate Token
            //byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            //byte[] key = Guid.NewGuid().ToByteArray();
            //string token = Convert.ToBase64String(time.Concat(key).ToArray());

            string token = RandomGenerator.Generate(45);
            return new Token
            {
                TokenText = token,
                EndDate = DateTime.Now.AddDays(expireDay),
            };
        }
        private AccountVerification CreateAccountVerificationCode(int UserID)
        {
            string verificationCode = RandomGenerator.Generate(6);

            return new AccountVerification
            {
                UserID = UserID,
                VerificationCode = verificationCode,
                ExpireTime = DateTime.Now.AddDays(7),
            };
        }
        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                User _user = _userRepository.Get(t => (t.Email == loginRequest.Email || t.Phone == loginRequest.Email)).FirstOrDefault();

                if (_user == null)
                {
                    loginResponse.SetError(Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD);
                    return loginResponse;
                }

                loginResponse.Username = _user.Username;

                if (_user.IsVerified == false)
                {
                    loginResponse.SetError(Constants.ResponseCode.FAILED);
                    return loginResponse;
                }

                if (_user.IsLocked && _user.LockedTime > DateTime.Now)
                {
                    loginResponse.SetError(Constants.ResponseCode.BANNED);
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
                            loginResponse.SetError(Constants.ResponseCode.BANNED);
                            return loginResponse;
                        }
                        else
                        {
                            loginResponse.SetError(Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD);
                            return loginResponse;
                        }
                    }
                    else
                    {
                        loginResponse.SetError(Constants.ResponseCode.SYSTEM_ERROR);
                        return loginResponse;
                    }
                }

                Token token = CreateToken();
                _user.WrongCount = 0;
                _user.Tokens.Add(token);

                if (_unitOfWork.SaveChanges() > 0)
                {
                    CacheManager.AddUserToCache(token.TokenText, _user);

                    loginResponse.Username = _user.FullName();
                    loginResponse.Token = token.TokenText;
                    loginResponse.SetError(Constants.ResponseCode.SUCCESS);
                    return loginResponse;
                }
            }
            catch ()
            {
                loginResponse.SetError(Constants.ResponseCode.SYSTEM_ERROR);
                return loginResponse;
            }

            return loginResponse;
        }
        public RegisterResponse UserRegistry(User user)
        {
            User _user = _userRepository.Get(t => t.Email == user.Email).FirstOrDefault();
            RegisterResponse registerResponse = new RegisterResponse();

            if (_user != null)
            {
                registerResponse.SetError(Constants.ResponseCode.EMAIL_IN_USE);
                return registerResponse;
            }

            _user = user;
            _user.Password = Cryptor.sha512encrypt(user.Password);//gelen userın pass'ini şifreleyip kayıt ettik.
            _accountVerificationRepository.Add(CreateAccountVerificationCode(user.ID));
            _userRepository.Add(_user);

            if (_unitOfWork.SaveChanges() > 0)
            {
                registerResponse.SetError(Constants.ResponseCode.SUCCESS);
                registerResponse.Username = _user.Username;
            }

            return registerResponse;
        }
        private RegisterResponse FacebookUserRegistry(User user)
        {
            RegisterResponse registerResponse = new RegisterResponse();
            User _user = user;
            _userRepository.Add(_user);

            if (_unitOfWork.SaveChanges() > 0)
            {
                registerResponse.SetError(Constants.ResponseCode.SUCCESS);
                registerResponse.Username = _user.Username;
            }
            else
            {
                registerResponse.SetError(Constants.ResponseCode.SYSTEM_ERROR);
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
                            CacheManager.AddUserToCache(token.TokenText, user);

                            loginResponse.Username = user.FullName();
                            loginResponse.Token = token.TokenText;
                            loginResponse.SetError(Constants.ResponseCode.SUCCESS);
                            return loginResponse;
                        }
                    }
                    catch (Exception ex)
                    {
                        loginResponse.SetError(Constants.ResponseCode.SYSTEM_ERROR);
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

                UserRegistry(user);
                _userRepository.Add(user);
            }
            catch
            {
                loginResponse.SetError(Constants.ResponseCode.SYSTEM_ERROR);
            }
            return loginResponse;
        }

        public LoginResponse CheckVerificationCode(string token, string code)
        {
            //Test Edilecek
            User user = CacheManager.GetUser(token);
            AccountVerification accountVerification = new AccountVerification();
            accountVerification = user.AccountVerifications.LastOrDefault(t => t.VerificationCode == code);
            LoginResponse loginResponse = new LoginResponse();
            if (accountVerification == null)
            {
                user.IsVerified = false;
                loginResponse.SetError(Constants.ResponseCode.FAILED);
                return loginResponse;
            }
            user.IsVerified = true;

            loginResponse.SetError(Constants.ResponseCode.SUCCESS);
            loginResponse.Username = user.Username;
            loginResponse.Token = token;

            return loginResponse;
        }

    }
}
