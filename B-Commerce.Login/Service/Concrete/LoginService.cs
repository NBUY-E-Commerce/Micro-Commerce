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

        public LoginResponse CheckToken(string token)
        {
            return null;
        }

        public Token CreateToken()
        {
            //Generate Token
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return new Token
            {
                TokenText = token,
                EndDate = DateTime.Now.AddHours(2),
            };
        }
        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                User _user = _userRepository.Get(t => t.Email == loginRequest.Email).FirstOrDefault();

                if (_user == null)
                {
                    loginResponse.Username = _user.Username;
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

                if (_user.Password != loginRequest.Password)
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
                        loginResponse.Code = (int)Constants.ResponseCode.SYSTEM;
                        loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
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
                    loginResponse.Code = (int)Constants.ResponseCode.SUCCESS;
                    loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
                    return loginResponse;
                }
            }
            catch (Exception ex)
            {
                loginResponse.Code = (int)Constants.ResponseCode.SYSTEM;
                loginResponse.Message = Constants.ResponseCodes[loginResponse.Code];
                return loginResponse;
            }

            return loginResponse;
        }
        public LoginResponse UserRegistry(User user)
        {
            throw new NotImplementedException();
        }
    }
}
