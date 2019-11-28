using B_Commerce.SMVC.Areas.Admin.ActionFilters;
using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes.Autentication.Login;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Areas.Admin.Controllers
{
    [AutenticationFilter]
    public class AccountController : Controller
    {
        // GET: Admin/Account
        
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginModel);
            }

            LoginResponse loginResponse = WebApiOperation.SendPost<LoginModel, LoginResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_LOGIN_URI, loginModel);

            if (loginResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)
            {
                //işlem basarılı

                UserAdmin.CurrentUserAdmin = new UserAdmin
                {
                    Name = loginResponse.Username,
                    ExpireDate = loginResponse.ExpireDate,
                    IsValid = loginResponse.IsVerify,
                    Token = loginResponse.Token,
                    Email = loginResponse.Email,
                };


                return View("~/Areas/Admin/Views/Home/Index2.cshtml", loginModel);
            }


            ViewBag.error = loginResponse.Message;
            return View("~/Areas/Admin/Views/Account/Login.cshtml", loginModel);
        }
    }
}