using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.Login.Common;
using B_Commerce.Login.DatabaseContext;
using B_Commerce.Login.DomainClass;
using B_Commerce.Login.Response;
using B_Commerce.Login.Service.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B_Commerce.LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        LoginDbContext loginDbContext;
        IUnitOfWork _unitOfWork;
        IRepository<User> _userRepository;
        IRepository<AccountVerification> _accountVerificationRepository;
        CacheManager CacheManager;

        [HttpPost]
        public LoginResponse Login(LoginRequest loginRequest)
        {

            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, CacheManager);

            LoginResponse loginResponse = new LoginResponse();

            loginResponse = loginService.Login(loginRequest);

            return loginResponse;

        }

        [HttpPost]
        public RegisterResponse UserRegistry(User user)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, CacheManager);
            RegisterResponse registerResponse = new RegisterResponse();
            registerResponse=loginService.UserRegistry(user);
            return registerResponse;
        }
  
        [HttpPost]
        public LoginResponse FacebookLogin(string fbcode)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, CacheManager);
            LoginResponse loginResponse = new LoginResponse();
            loginResponse=loginService.FacebookLogin(fbcode);
            return loginResponse;
        }
        [HttpPost]
        public LoginResponse CheckVerificationCode(string token, string code)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, CacheManager);
            LoginResponse loginResponse = new LoginResponse();
            loginResponse=loginService.CheckVerificationCode(token,code);
            return loginResponse;
        }

    }
}