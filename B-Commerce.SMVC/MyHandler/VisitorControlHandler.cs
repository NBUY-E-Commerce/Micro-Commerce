using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.WebApiReqRes.Autentication.Login;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace B_Commerce.SMVC.MyHandler
{
    public class VisitorControlHandler : System.Web.Mvc.IActionFilter
    {
        public RequestContext RequestContext { get; set; }
        public VisitorControlHandler() { }
        public VisitorControlHandler(RequestContext RequestContext) { this.RequestContext = RequestContext; }
        public bool IsReusable { get; }



        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SystemUser.CurrentUser != null)
            {
                //demekki login olmus bir kullanıcı var contexte


            }
            else
            {
                //login olmamaıs bir kullanıcı

                HttpCookie cok = filterContext.HttpContext.Request.Cookies["visitortoken"];
                if (cok == null)
                {
                    VisitorTokenResponse visitorResponse = WebApiOperation.SendPost<int, VisitorTokenResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_CreateVisitorToken_URI, 7);

                    if (visitorResponse.Code == 0)
                    {

                        HttpCookie cookie = new HttpCookie("visitortoken");
                        cookie.Value = visitorResponse.Token;
                        cookie.Expires = visitorResponse.ExpireDate;
                        filterContext.HttpContext.Response.Cookies.Add(cookie);


                    }


                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
        }
    }

}