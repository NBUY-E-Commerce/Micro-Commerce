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
using Swashbuckle.AspNetCore.Annotations;

namespace B_Commerce.LoginApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILoginService _loginService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(ILoginService loginService, IHttpContextAccessor httpContextAccessor)
        {
            _loginService = loginService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost]
        [Route("Login")]
        [SwaggerOperation(Summary = "login işlemi yapar", Description = "Gets two hardcoded values")]
        public LoginResponse Login(LoginRequest loginRequest)
        {

            return _loginService.Login(loginRequest);
        }

        [HttpPost]
        [Route("UserRegistry")]
        public RegisterResponse UserRegistry(RegisterRequest request)
        {

            var user = new User
            {
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                Surname = request.Surname,
                Password = request.Password,
                Username = request.Email
            };

            return _loginService.UserRegistry(user);
        }

        [HttpPost]
        [Route("FacebookLogin")]
        public LoginResponse FacebookLogin(FacebookRequest facebookRequest)
        {
            return _loginService.FacebookLogin(facebookRequest);
        }
        [HttpPost]
        [Route("CheckVerificationCode")]
        public BaseResponse CheckVerificationCode(VerificationRequest request)
        {
            return _loginService.CheckVerificationCode(request.Email, request.Code);
        }

        [HttpPost]
        [Route("SendPasswordChangeCode")]
        [SwaggerOperation(Summary = "şifre değişikliği için kod gönderim işlemi yapar", Description = "Gets two hardcoded values")]
        public PasswordChangeResponse SendPasswordChangeCode(PasswordChangeRequest passwordChangeRequest)
        {
            return _loginService.SendPasswordChangeCode(passwordChangeRequest.Email);
        }

        [HttpPost]
        [Route("CheckPasswordChangeCode")]
        public PasswordChangeResponse CheckPasswordChangeCode(PasswordChangeRequest passwordChangeRequest)
        {
            return _loginService.CheckPasswordChangeCode(passwordChangeRequest.Email, passwordChangeRequest.PassChangeCode);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public PasswordChangeResponse ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            return _loginService.ChangePassword(changePasswordRequest.Email, changePasswordRequest.PassChangeCode, changePasswordRequest.Password);
        }

        [HttpPost]
        [Route("ChangePassword2")]
        public PasswordChangeResponse ChangePassword(int UserID, string oldPassword, string newPassword)
        {
            return _loginService.ChangePassword(UserID, oldPassword, newPassword);
        }

        [HttpPost]
        [Route("SendAccountVerificationCode")]
        public VerificationResponse SendAccountVerificationCode(string Email)
        {
            return _loginService.SendAccountVerificationCode(Email);
        }

        [Route("CreateVisitorToken")]
        [HttpPost]
        public IActionResult CreateVisitorToken([FromBody]int ExpireTime = 7)
        {
            VisitorTokenResponse response = _loginService.CreateVisitorToken();
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(201, response);
        }
    }
}