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
using B_Commerce.Login.Service.Abstract;
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
        ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        [Route("Login")]
        public LoginResponse Login(LoginRequest loginRequest)
        {
            return _loginService.Login(loginRequest);
        }

        [HttpPost]
        [Route("UserRegistry")]
        public RegisterResponse UserRegistry(User user)
        {
            return _loginService.UserRegistry(user);
        }

        [HttpPost]
        [Route("FacebookLogin")]
        public LoginResponse FacebookLogin(string fbcode)
        {
            return _loginService.FacebookLogin(fbcode);
        }
        [HttpPost]
        [Route("CheckVerificationCode")]
        public VerificationResponse CheckVerificationCode(int UserID, string code)
        {
            return _loginService.CheckVerificationCode(UserID, code);
        }

    }
}