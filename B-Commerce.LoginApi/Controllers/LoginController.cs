using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.Login.Common;
using B_Commerce.Login.DatabaseContext;
using B_Commerce.Login.DomainClass;
using B_Commerce.Login.Request;
using B_Commerce.Login.Response;
using B_Commerce.Login.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B_Commerce.LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        IRepository<User> _userRepository;
        IRepository<AccountVerification> _accountVerificationRepository;
        CacheManager _CacheManager;
        public LoginController(IUnitOfWork unitOfWork, IRepository<User> userRepository, IRepository<AccountVerification> accountVerificationRepository, CacheManager CacheManager)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _accountVerificationRepository = accountVerificationRepository;
            _CacheManager = CacheManager;
        }
        [HttpPost]
        [Route("Login")]
        public LoginResponse Login(LoginRequest loginRequest)
        {

            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);
            return loginService.Login(loginRequest);

        }

        [HttpPost]
        [Route("UserRegistry")]
        public RegisterResponse UserRegistry(User user)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);
            return loginService.UserRegistry(user);
        }

        [HttpPost]
        [Route("FacebookLogin")]
        public LoginResponse FacebookLogin(string fbcode)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);
            return loginService.FacebookLogin(fbcode);
        }
        [HttpPost]
        [Route("CheckVerificationCode")]
        public VerificationResponse CheckVerificationCode(int UserID, string code)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);
            return loginService.CheckVerificationCode(UserID, code);
        }

    }
}