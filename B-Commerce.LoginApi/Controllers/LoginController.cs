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
        public LoginResponse Login(string email, string password)
        {

            LoginService loginService = new LoginService(_unitOfWork, _userRepository, _accountVerificationRepository, CacheManager);

            LoginResponse loginResponse = new LoginResponse();

            loginResponse = loginService.Login(new B_Commerce.Login.Request.LoginRequest { Email = email, Password = password });

            return loginResponse;


        }
    }
}