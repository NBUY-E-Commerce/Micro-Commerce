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

    public class AccountController : Controller
    {
        // GET: Admin/Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
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

                if (!loginResponse.UserRole.Contains("Admin"))
                {
                    ViewBag.error = "Yetkisiz kullanıcı";
                    return View("Login", loginModel);

                }

                UserAdmin.CurrentUserAdmin = new UserAdmin
                {
                    Name = loginResponse.Username,
                    ExpireDate = loginResponse.ExpireDate,
                    IsValid = loginResponse.IsVerify,
                    Token = loginResponse.Token,
                    Email = loginResponse.Email,
                    Roles = loginResponse.UserRole
                };


                return RedirectToAction("Index", "Home");
               
            }


            ViewBag.error = loginResponse.Message;

            return View(loginModel);

            //return View("~/Areas/Admin/Views/Account/Login.cshtml", loginModel);
        }
    }
}