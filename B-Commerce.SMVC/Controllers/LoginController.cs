using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes;
using B_Commerce.SMVC.WebApiReqRes.Autentication.Login;
using B_Commerce.SMVC.WebHelpers;
using DotNetOpenAuth.AspNet.Clients;
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
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(PasswordChangeRequest passwordChangeRequest)
        {
            PasswordChangeResponse passwordChangeResponse = WebApiOperation.SendPost<PasswordChangeRequest, PasswordChangeResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_SEND_PASSWORD_CHANGE_CODE_URI, passwordChangeRequest);
            if (true)
            {

            }

            return RedirectToAction("PasswordVerify", "Login", new { Email = passwordChangeResponse.Email });
        }
        public ActionResult PasswordVerify(string Email)
        {
            return View((object)Email);
        }
        [HttpPost]
        public ActionResult PasswordVerify(PasswordChangeRequest passwordChangeRequest)
        {
            PasswordChangeResponse passwordChangeResponse = WebApiOperation.SendPost<PasswordChangeRequest, PasswordChangeResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_CHECK_PASSWORD_CHANGE_CODE_URI, passwordChangeRequest);

            if (passwordChangeResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)//başarılı ise
            {
                return RedirectToAction("ChangePassword", "Login", passwordChangeResponse);
            }

            ViewBag.error = passwordChangeResponse.Message;
            return View("/Views/Login/PasswordVerify.cshtml", new { Email = passwordChangeResponse.Email, PassChangeCode = passwordChangeRequest.PassChangeCode });
        }
        public ActionResult ChangePassword(string Email, string PassChangeCode)
        {
            return View((object)new { Email = Email, PassChangeCode = PassChangeCode });
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            PasswordChangeResponse passwordChangeResponse = WebApiOperation.SendPost<ChangePasswordRequest, PasswordChangeResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_CHANGE_PASSWORD_URI, changePasswordRequest);

            if (passwordChangeResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)//başarılı ise
            {
                TempData["reason"] = "PasswordChanged";
                TempData["popupmessage"] = "Şifreniz başarılı şekilde değiştirilmiştir.Yeni şifreniz ile giriş yapabilirsiniz.";
                return RedirectToAction("Register", "Login");
            }

            ViewBag.error = passwordChangeResponse.Message;
            return View("/Views/Login/PasswordVerify.cshtml", new { Email = passwordChangeResponse.Email });
        }

        public ActionResult DoRegister(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                var model = new RegisterViewModel();
                model.registerModel = registerModel;
                return View("Register", model);
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
                var model = new RegisterViewModel();
                model.loginModel = loginModel;

                return View("Register", model);
            }

            LoginResponse loginResponse = WebApiOperation.SendPost<LoginModel, LoginResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_LOGIN_URI, loginModel);

            if (loginResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)
            {
                SystemUser.CurrentUser = new SystemUser
                {
                    Name = loginResponse.Username,
                    ExpireDate = loginResponse.ExpireDate,
                    IsValid = loginResponse.IsVerify,
                    Token = loginResponse.Token,
                    Email = loginResponse.Email,
                };

                if (!loginResponse.IsVerify)
                {
                    return RedirectToAction("VerifyAccount", "Login", new
                    {
                        email = loginResponse.Email
                    });
                }

                return RedirectToAction("Index", "Home");
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

        public ActionResult Logout()
        {
            SystemUser.CurrentUser = null;
            TempData["reason"] = "ActivateUser";
            TempData["popupmessage"] = "Çıkış İşlemi Başarılı. Tekrar Bekleriz...";

            return RedirectToAction("Index", "Home");
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
                TempData["reason"] = "ActivateUser";
                TempData["popupmessage"] = "Aktivasyon işleminiz başarılı.Keyifli alışverişler.";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.error = response.Message;
            return View("/Views/Login/VerifyAccount.cshtml", (object)email);

        }
        public void FbLogin()
        {
            var fb = new FacebookClient(Constants.FACEBOOK_APPID, Constants.FACEBOOK_APPSECRET, "email");

            fb.RequestAuthentication(this.HttpContext, new Uri(Constants.MVC_FACEBOOK_URI));
        }

        public ActionResult FacebookLogin()
        {
            Facebook.FacebookClient fb = new Facebook.FacebookClient();
            LoginResponse loginResponse = new LoginResponse();
            FacebookModel facebookModel = new FacebookModel();

            if (Request.QueryString["code"] != null)
            {
                facebookModel.FacebookCode = Request.QueryString["code"];
                loginResponse = WebApiOperation.SendPost<FacebookModel, LoginResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_FACEBOOK_URI, facebookModel);

                if (loginResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)
                {
                    SystemUser.CurrentUser = new SystemUser
                    {
                        Name = loginResponse.Username,
                        ExpireDate = loginResponse.ExpireDate,
                        IsValid = loginResponse.IsVerify,
                        Token = loginResponse.Token,
                        Email = loginResponse.Email
                    };
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}