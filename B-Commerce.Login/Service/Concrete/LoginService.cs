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

                checkTokenResponse.Code = (int)Constants.ResponseCode.INVALID_TOKEN;
                checkTokenResponse.Message = Constants.ResponseCodes[checkTokenResponse.Code];
                return checkTokenResponse;
            }
            checkTokenResponse.Code = (int)Constants.ResponseCode.SUCCESS;
            checkTokenResponse.Message = Constants.ResponseCodes[checkTokenResponse.Code];
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
                UserID=UserID,
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
            catch (Exception ex)
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

                registerResponse.Code = (int)Constants.ResponseCode.EMAIL_IN_USE;
                registerResponse.Message = Constants.ResponseCodes[registerResponse.Code];
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
