﻿using B_Commerce.Common.Repository;
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
using System.Net.Http;
using System.Threading.Tasks;
using B_Commerce.Login.FluentValidation;
using FluentValidation.Results;

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
            checkTokenResponse.Username = user.Username;
            checkTokenResponse.ExpireDate = user.Tokens.FirstOrDefault(t => t.TokenText == token).EndDate;
            if (user.IsVerified != true)
            {
                checkTokenResponse.SetStatus(Constants.ResponseCode.ISNOTVERIFIED);
                return checkTokenResponse;
            }


            checkTokenResponse.SetStatus(Constants.ResponseCode.SUCCESS);
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

            LoginRequestValidator validator = new LoginRequestValidator();
            ValidationResult result = validator.Validate(loginRequest);

            if (result.IsValid == false)
            {
                loginResponse.setValidator(result);
                return loginResponse;
            }

            try
            {
                User _user = _userRepository.Get(t => (t.Email == loginRequest.Email || t.Phone == loginRequest.Phone)).FirstOrDefault();

                if (_user == null)
                {
                    loginResponse.SetStatus(Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD);
                    return loginResponse;
                }

                loginResponse.Username = _user.Username;



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

                    loginResponse.IsVerify = _user.IsVerified;
                    loginResponse.Username = _user.FullName();
                    loginResponse.Token = token.TokenText;
                    loginResponse.ExpireDate = token.EndDate;
                    loginResponse.Email = _user.Email;
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

                string passwordNotHash = user.Password;
                user.Password = Cryptor.sha512encrypt(user.Password);
                //şifreleme
                //*** dikkat user repoya eklenmeden bağlı tablolarına veri eklenirse bu tabloların takibi sağlamaz
                //kullanıcıyı olusturtur depoya ekle sonra bağlı tablolarını ekle
                _userRepository.Add(user);
                user.SocialInfos.Add(user.SocialInfos.FirstOrDefault());

                AccountVerification accountVerification = new AccountVerification();
                if (user.SocialInfos.Count == 0)
                {
                    accountVerification = CreateAccountVerificationCode();
                    user.AccountVerifications.Add(accountVerification);
                }


                if (_unitOfWork.SaveChanges() > 0)
                {

                    LoginResponse loginResponse = Login(new LoginRequest
                    {
                        Email = user.Email,
                        Password = passwordNotHash
                    });

                    if (loginResponse.Code != 0)
                    {
                        registerResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                        return registerResponse;

                    }
                    if (!user.IsVerified)
                    {
                        MailRequest mailRequest = new MailRequest
                        {
                            ToMail = user.Email,
                            ToName = user.FullName(),
                            Subject = "B-Commerce E-Mail Onayı",
                            Body = $"Merhaba {user.FullName()}\n Email onaylama kodunuz: {accountVerification.VerificationCode}",
                            ProjectCode = "123456"
                        };

                        HttpClient httpClient = new HttpClient();
                        httpClient.BaseAddress = new Uri("http://localhost:60017");
                        Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync("/api/Notification/Mail", mailRequest);

                        if (!httpResponse.Result.IsSuccessStatusCode)
                        {
                            registerResponse.SetStatus(Constants.ResponseCode.FAILED);
                            return registerResponse;
                        }
                    }

                    registerResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                    registerResponse.Username = user.Username;
                    registerResponse.Token = loginResponse.Token;
                    registerResponse.ExpireDate = loginResponse.ExpireDate;
                    registerResponse.Email = user.Email;
                }
            }
            catch (Exception ex)
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
                    redirect_uri = "https://localhost:44314/Login/FacebookLogin",
                    //Test ederken kendi mvc projenin localhost kısmını yaz.
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
                            loginResponse.ExpireDate = token.EndDate;
                            loginResponse.IsVerify = true;
                            loginResponse.Email = user.Email;
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
                user = new User();//newlemezsek patlıyor.
                user.Email = email;
                user.Name = firstName;
                user.Surname = lastName;
                user.Password = firstName;
                user.Username = firstName + lastName;
                user.IsVerified = true;

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
            catch (Exception ex)
            {
                loginResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
            }
            return loginResponse;
        }

        public BaseResponse CheckVerificationCode(string email, string code)
        {
            User user = _userRepository.Get(t => t.Email == email).FirstOrDefault();

            AccountVerification accountVerification = user.AccountVerifications.FirstOrDefault(t => t.VerificationCode == code);
            BaseResponse verificationResponse = new BaseResponse();

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
            try
            {
                if (_unitOfWork.SaveChanges() > 0)
                {
                    verificationResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                }
                else
                {
                    verificationResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                }
            }
            catch (Exception ex)
            {
                //mongodb log at.
                verificationResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
            }

            return verificationResponse;
        }

        public PasswordChangeResponse SendPasswordChangeCode(string Email)
        {
            PasswordChangeResponse response = new PasswordChangeResponse();
            if (Email == null || Email == "")
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }
            User user = _userRepository.Get(t => t.Email == Email).FirstOrDefault();

            if (user == null)
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }

            string PassChangeCode = RandomGenerator.Generate(6);

            MailRequest mailRequest = new MailRequest
            {
                ToMail = user.Email,
                ToName = user.FullName(),
                Subject = "B-Commerce Şifre Yenileme",
                Body = $"Şifre yenileme kodunuz: {PassChangeCode}",
                ProjectCode = "123456"
            };


            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60017");

            Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync("/api/Notification/Mail", mailRequest);

            if (!httpResponse.Result.IsSuccessStatusCode)
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }


            try
            {
                user.PasswordChange = new PasswordChange { ChangeCode = PassChangeCode, Email = user.Email };
                _unitOfWork.SaveChanges();
                response.Email = user.Email;
                response.SetStatus(Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception)
            {
                response.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                return response;
            }

        }

        public PasswordChangeResponse CheckPasswordChangeCode(string Email, string Code)
        {
            PasswordChangeResponse response = new PasswordChangeResponse();
            if (Email == null || Email == "" || Code == null || Code == "")
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }
            User user = _userRepository.Get(t => t.Email == Email).FirstOrDefault();
            if (user == null)
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }
            if (user.PasswordChange.ChangeCode != Code)
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }

            if (user.PasswordChange.IsExpired())
            {
                response.SetStatus(Constants.ResponseCode.EXPIRED_CODE);
                return response;
            }

            response.Email = user.Email;
            response.PassChangeCode = user.PasswordChange.ChangeCode;
            response.SetStatus(Constants.ResponseCode.SUCCESS);
            return response;
        }

        public PasswordChangeResponse ChangePassword(string Email, string Code, string newPassword)
        {
            PasswordChangeResponse response = CheckPasswordChangeCode(Email, Code);

            try
            {
                if (response.Code == (int)Constants.ResponseCode.SUCCESS)
                {
                    User user = _userRepository.Get(t => t.Email == Email).FirstOrDefault();
                    user.Password = Cryptor.sha512encrypt(newPassword);

                    _userRepository.Update(user);
                    _unitOfWork.SaveChanges();
                    response.SetStatus(Constants.ResponseCode.SUCCESS);
                    return response;
                }
                else
                {
                    response.SetStatus(Constants.ResponseCode.FAILED);
                    return response;
                }

            }
            catch (Exception)
            {

                response.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                return response;
            }

        }

        public PasswordChangeResponse ChangePassword(int UserID, string oldPassword, string newPassword)
        {
            PasswordChangeResponse response = new PasswordChangeResponse();
            User user = _userRepository.Get(t => t.ID == UserID && t.Password == Cryptor.sha512encrypt(oldPassword)).FirstOrDefault();
            if (user == null)
            {
                response.SetStatus(Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD);
                return response;
            }

            try
            {
                user.Password = Cryptor.sha512encrypt(newPassword);
                _userRepository.Update(user);
                _unitOfWork.SaveChanges();
                response.SetStatus(Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception)
            {
                response.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                return response;
            }
        }

        public VerificationResponse SendAccountVerificationCode(string Email)
        {
            VerificationResponse response = new VerificationResponse();
            if (Email == null || Email == "")
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }

            User user = _userRepository.Get(t => t.Email == Email).FirstOrDefault();

            if (user == null)
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }

            AccountVerification accountVerification = CreateAccountVerificationCode();

            MailRequest mailRequest = new MailRequest
            {
                ToMail = user.Email,
                ToName = user.FullName(),
                Subject = "B-Commerce E-Mail Onayı",
                Body = $"Merhaba {user.FullName()}\n Email onaylama kodunuz: {accountVerification.VerificationCode}",
                ProjectCode = "123456"
            };


            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:60017");

            Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync("/api/Notification/Mail", mailRequest);

            if (!httpResponse.Result.IsSuccessStatusCode)
            {
                response.SetStatus(Constants.ResponseCode.FAILED);
                return response;
            }


            try
            {
                user.AccountVerifications.Add(accountVerification);
                _unitOfWork.SaveChanges();
                response.SetStatus(Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception)
            {
                response.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                return response;
            }

        }

    }
}
