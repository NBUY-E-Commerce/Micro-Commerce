using B_Commerce.Common.Repository.Abstract;
using B_Commerce.Common.UnitOfWork.Abstract;
using B_Commerce.Login.Common;
using B_Commerce.Login.DomainClass;
using B_Commerce.Login.Response;
using B_Commerce.Login.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static B_Commerce.Login.Common.Constants;

namespace B_Commerce.Login.Service.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;
        //Login service'in constructor'ında log nesnenide olacak...
        public LoginService(IUnitOfWork unitOfWork, IRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public Token CreateToken()
        {
            //şifreleme yapılacak
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return new Token
            {
                TokenText = token
            };
        }
        public LoginResponse Login(User user)
        {
            LoginResponse loginResponse = new LoginResponse();
            try
            {
                User _user;
                if ((_user = UserNameControl(user)) != null)
                {
                    if (UserPasswordControl(user))
                    {
                        _user.Tokens.Add(CreateToken());

                        int result = _unitOfWork.Save();
                        if (result == 0)
                        {
                            loginResponse.Code = (int)ResponseCode.SYSTEM;
                        }
                        else
                        {
                            loginResponse.Token = _user.Tokens.Last().TokenText;
                            loginResponse.Username = _user.Username;
                        }
                    }
                    else
                    {
                        //Banlanacak methodu çağır.
                        _user.WrongCount++;
                        if (_user.WrongCount >= 5) loginResponse.Code = (int)UserBan(_user);
                        else
                        {
                            loginResponse.Code = (int)ResponseCode.INVALID_USERNAME_OR_PASSWORD;
                        }
                        _unitOfWork.Save();
                    }
                }
                //İsim doğru ama banlı
                else if (IsUserBanned(user))
                {
                    loginResponse.Code = (int)ResponseCode.BANNED;
                }
                else
                {
                    loginResponse.Code = (int)ResponseCode.INVALID_USERNAME_OR_PASSWORD;
                }
            }
            catch (Exception ex)
            {
                //db olayı gelicek RabbitMQ
                throw new Exception("Dbye Loglandı" + ex);
            }

            return loginResponse;
        }

        public ResponseCode UserAdd(User user)
        {
            //user şifresini veritabanına hashleyerek koy
            if (UserControl(user) == true) throw new Exception("Böyle bir kullanıcı var");
            _userRepository.Add(user);
            int result = _unitOfWork.Save();
            return result == 1 ? ResponseCode.SUCCESS : ResponseCode.FAILED;
        }
        public ResponseCode UserBan(User user)
        {
            User _user = user;
            _user.BannedUntil = DateTime.Now.AddDays(1);
            _user.WrongCount = 0;

            return ResponseCode.BANNED;
        }
        public bool IsUserBanned(User user)
        {
            User _user = _userRepository.Get(t => (t.Username == user.Username || t.Phone == user.Phone) && t.BannedUntil > DateTime.Now).FirstOrDefault();
            return _user == null ? false : true;
        }
        public bool UserControl(User user)
        {
            User _user = UserGet(user);
            return _user == null ? false : true;
        }
        public bool UserPasswordControl(User user)
        {
            User _user = UserGet(user);
            return _user == null ? false : true;
        }
        public User UserNameControl(User user)
        {
            User _user = _userRepository.Get(t => (t.Username == user.Username || t.Phone == user.Phone) && t.BannedUntil < DateTime.Now).FirstOrDefault();
            return _user;
        }

        public ResponseCode UserDelete(User user)
        {
            int result = 0;
            if (UserControl(user) == true)
            {
                _userRepository.Delete(user);
                result = _unitOfWork.Save();
            }
            return result == 1 ? ResponseCode.SUCCESS : ResponseCode.FAILED;
        }

        public User UserGet(User user)
        {
            User _user = _userRepository.Get(t => (t.Username == user.Username || t.Phone == user.Phone) && t.Password == user.Password).FirstOrDefault();
            return _user;
        }

        public ResponseCode UserUpdate(User user)
        {
            int result = 0;
            if (UserControl(user) == true)
            {
                _userRepository.Update(user);
                result = _unitOfWork.Save();
            }
            return result == 1 ? ResponseCode.SUCCESS : ResponseCode.FAILED;
        }
    }
}
