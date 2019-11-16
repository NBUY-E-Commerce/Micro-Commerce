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
        //Login service'in constructor'ında log nesneside olacak...
        public LoginService(IUnitOfWork unitOfWork, IRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public CheckTokenResponse CheckToken(string token)
        {
            User user = CacheManager.GetUser(token);
            CheckTokenResponse checkTokenResponse = new CheckTokenResponse();
            if (user == null)
            {

                checkTokenResponse.Code = (int)Constants.ResponseCode.INVALID_TOKEN;
                checkTokenResponse.Message = Constants.ResponseCodes[checkTokenResponse.Code];
                return checkTokenResponse;
            }
            checkTokenResponse.Code = (int)Constants.ResponseCode.SUCCESS;
            checkTokenResponse.Message = Constants.ResponseCodes[checkTokenResponse.Code];
            checkTokenResponse.Username = user.Username;

            return checkTokenResponse;

        }

        private Token CreateToken()
        {
            //Generate Token
            //byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            //byte[] key = Guid.NewGuid().ToByteArray();
            //string token = Convert.ToBase64String(time.Concat(key).ToArray());

            string token = RandomGenerator.Generate(45);
            return new Token
            {
                TokenText = token,
                EndDate = DateTime.Now.AddHours(2),
            };
        }
        private AccountVerification CreateAccountVerificationCode()
        {
            string verificationCode = RandomGenerator.Generate(15);
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
                User _user = _userRepository.Get(t => (t.Email == loginRequest.Email || t.Phone == loginRequest.Email)).FirstOrDefault();

                if (_user == null)
                {
                    loginResponse.Code = (int)Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD;
                    loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
                    return loginResponse;
                }

                if (_user.IsLocked && _user.LockedTime > DateTime.Now)
                {
                    loginResponse.Username = _user.Username;
                    loginResponse.Code = (int)Constants.ResponseCode.BANNED;
                    loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
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
                            loginResponse.Username = _user.Username;
                            loginResponse.Code = (int)Constants.ResponseCode.BANNED;
                            loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
                            return loginResponse;
                        }
                        else
                        {
                            loginResponse.Username = _user.Username;
                            loginResponse.Code = (int)Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD;
                            loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
                            return loginResponse;
                        }
                    }
                    else
                    {
                        loginResponse.Code = (int)Constants.ResponseCode.SYSTEM_ERROR;
                        loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
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
                    loginResponse.Code = (int)Constants.ResponseCode.SUCCESS;
                    loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
                    return loginResponse;
                }
            }
            catch (Exception ex)
            {
                loginResponse.Code = (int)Constants.ResponseCode.SYSTEM_ERROR;
                loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
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

                registerResponse.Code = (int)Constants.ResponseCode.EMAIL_IN_USE;
                registerResponse.Message = Constants.ResponseCodes[registerResponse.Code];
                return registerResponse;

            }
            _user = user;
            _user.Password = Cryptor.sha512encrypt(user.Password);//gelen userın pass'ini şifreleyip kayıt ettik.
            _user.AccountVerifications.Add(CreateAccountVerificationCode());
            _userRepository.Add(_user);

            if (_unitOfWork.SaveChanges() > 0)
            {
                registerResponse.Code = (int)Constants.ResponseCode.SUCCESS;
                registerResponse.Message = Constants.ResponseCodes[registerResponse.Code];
                registerResponse.Username = _user.Username;
            }

            return registerResponse;
        }

        public LoginResponse FacebookLogin(LoginRequest loginRequest)
        {
            return null;
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
                loginResponse.Code = (int)Constants.ResponseCode.FAILED;
                loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
                return loginResponse;
            }
            user.IsVerified = true;

            loginResponse.Code = (int)Constants.ResponseCode.SUCCESS;
            loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
            loginResponse.Username = user.Username;
            loginResponse.Token = token;

            return loginResponse;
        }
    }
}
