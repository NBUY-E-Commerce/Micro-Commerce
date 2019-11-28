using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes;
using B_Commerce.SMVC.WebApiReqRes.Autentication.Login;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Register()
        {


            return View(new RegisterViewModel());
        }

        public ActionResult DoRegister(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View("");
            }

            RegisterResponse registerResponse = WebApiOperation.SendPost<RegisterModel, RegisterResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_REGISTER_URI, registerModel);
            if (registerResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)
            {
                //işlem basarılı
                SystemUser.CurrentUser = new SystemUser
                {
                    Name = registerResponse.Username,
                    ExpireDate = registerResponse.ExpireDate,
                    IsValid = registerResponse.IsValid,
                    Token = registerResponse.Token,
                    Email = registerResponse.Email,
                };

                return RedirectToAction("VerifyAccount", "Login", new
                {
                    email = registerResponse.Email
                });

            }
            var viewModel = new RegisterViewModel
            {
                registerModel = registerModel

            };

            ViewBag.registererror = registerResponse.Message;
            return View("/Views/Login/Register.cshtml", viewModel);

        }

        public PartialViewResult TopBar()
        {

            return PartialView("_PartialTopBar");

        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View("");
            }

            LoginResponse loginResponse = WebApiOperation.SendPost<LoginModel, LoginResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_LOGIN_URI, loginModel);

            if (loginResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)
            {
                //işlem basarılı

            }

            var viewModel = new RegisterViewModel
            {
                loginModel = loginModel

            };
            ViewBag.error = loginResponse.Message;
            return View("/Views/Login/Register.cshtml", viewModel);


        }


        public ActionResult VerifyAccount(string email)
        {

            return View((object)email);
        }

        public ActionResult DoVerify(string email, string code)
        {

            CommonResponse response = WebApiOperation.SendPost<VerificationRequest, CommonResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_CHECK_VERIFICATION_URI, new VerificationRequest
            {
                Email = email,
                Code = code

            });

            if (response.Code == Constants.LOGIN_RESPONSE_SUCCESS)
            {

                SystemUser.CurrentUser.IsValid = true;
                return RedirectToAction("Index", "Home");

            }

            ViewBag.error = response.Message;
            return View("/Views/VerifyAccount.cshtml", (object)email);

        }
    }
}