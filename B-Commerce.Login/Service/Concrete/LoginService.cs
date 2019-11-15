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

        Token CreateToken(double expireDay = 1)
        {
            string token = RandomGenerator.Generate(20);
            token = Cryptor.md5encrypt(token);
            return new Token
            {
                TokenText = token,
                EndDate = DateTime.Now.AddDays(expireDay),
            };
        }

        AccountVerification CreateVerificationCode(int userID)
        {
            return new AccountVerification { UserID = userID, VerificationCode = RandomGenerator.Generate(6), ExpireDate = DateTime.Now.AddDays(7) };

        }
        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                User _user = _userRepository.Get(t => t.Email == loginRequest.Email).FirstOrDefault();

                if (_user == null)
                {
                    loginResponse.SetError(Constants.ResponseCode.INVALID_USERNAME_OR_PASSWORD);
                    return loginResponse;
                }

                loginResponse.Username = _user.Username;

                if (_user.IsVerified == false)
                {
                    loginResponse.SetError(Constants.ResponseCode.NOT_VERIFIED);
                    return loginResponse;
                }

                if (_user.IsLocked && _user.LockedTime > DateTime.Now)
                {
                    loginResponse.SetError(Constants.ResponseCode.BANNED);
                    return loginResponse;
                }

                if (_user.IsLocked) { _user.IsLocked = false; _user.WrongCount = 0; }

                if (_user.Password != loginRequest.Password)
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
                        loginResponse.SetError(Constants.ResponseCode.SYSTEM);
                        return loginResponse;
                    }
                }

                Token token = CreateToken();
                _user.WrongCount = 0;
                _user.Tokens.Add(token);

                if (_unitOfWork.SaveChanges() > 0)
                {
                    loginResponse.Username = _user.FullName();
                    loginResponse.Token = token.TokenText;
                    loginResponse.SetError(Constants.ResponseCode.SUCCESS);
                    return loginResponse;
                }
            }
            catch (Exception ex)
            {
                loginResponse.SetError(Constants.ResponseCode.SYSTEM);
                return loginResponse;
            }

            return loginResponse;
        }
        public RegisterResponse UserRegistry(User user)
        {
            _userRepository.Add(user);
            _accountVerificationRepository.Add(CreateVerificationCode(user.ID));
            RegisterResponse response = new RegisterResponse();
            try
            {
                if (_unitOfWork.SaveChanges() > 0)
                {
                    response.Username = user.Username;
                    response.Email = user.Email;
                    response.SetError(Constants.ResponseCode.SUCCESS);
                    return response;
                }
            }
            catch (Exception)
            {
                response = new RegisterResponse();
                response.SetError(Constants.ResponseCode.FAILED);
                return response;
            }

            response.SetError(Constants.ResponseCode.SYSTEM);
            return response;


        }

        public bool Verify(User user, string code)
        {
            try
            {
                AccountVerification accountVerification = _accountVerificationRepository.Get(t => t.ID == user.ID && t.isDeleted == false).FirstOrDefault();
               
                if (accountVerification.VerificationCode != code)
                {
                    return false;
                }

                return true;

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
