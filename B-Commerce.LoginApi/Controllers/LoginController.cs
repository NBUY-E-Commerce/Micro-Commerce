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
        DbContext _loginDbContext;
        IUnitOfWork _unitOfWork;
        IRepository<User> _userRepository;
        IRepository<AccountVerification> _accountVerificationRepository;
        CacheManager _CacheManager;
        public LoginController(IUnitOfWork unitOfWork, IRepository<User> userRepository, IRepository<AccountVerification> accountVerificationRepository,CacheManager CacheManager, LoginDbContext loginDbContext)
        {
            _loginDbContext = loginDbContext;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _accountVerificationRepository = accountVerificationRepository;
        }
        [HttpPost]
        [Route("Login")]
        public LoginResponse Login(LoginRequest loginRequest)
        {

            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);

            LoginResponse loginResponse = new LoginResponse();

            loginResponse = loginService.Login(loginRequest);

            return loginResponse;

        }

        [HttpPost]
        [Route("UserRegistry")]
        public RegisterResponse UserRegistry(User user)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);
            RegisterResponse registerResponse = new RegisterResponse();
            registerResponse=loginService.UserRegistry(user);
            return registerResponse;
        }
  
        [HttpPost]
        [Route("FacebookLogin")]
        public LoginResponse FacebookLogin(string fbcode)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);
            LoginResponse loginResponse = new LoginResponse();
            loginResponse=loginService.FacebookLogin(fbcode);
            return loginResponse;
        }
        [HttpPost]
        [Route("CheckVerificationCode")]
        public LoginResponse CheckVerificationCode(string token, string code)
        {
            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, _CacheManager);
            LoginResponse loginResponse = new LoginResponse();
            loginResponse=loginService.CheckVerificationCode(token,code);
            return loginResponse;
        }

    }
}