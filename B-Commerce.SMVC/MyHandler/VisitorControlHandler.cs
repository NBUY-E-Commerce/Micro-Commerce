using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.WebApiReqRes.Autentication.Login;
using B_Commerce.SMVC.WebApiReqRes.ShoppingCart;
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
                HttpCookie cok = filterContext.HttpContext.Request.Cookies["visitortoken"];
                if (cok != null)// visitor dan gelmiş login olmuş
                {
                    //ilk defa geldiginde visitortoken i boşalt,
                    //
                }
            }
            else
            {
                //login olmamaıs bir kullanıcı

                HttpCookie cok = filterContext.HttpContext.Request.Cookies["visitortoken"];
                if (cok == null || Convert.ToDateTime(cok["date"])<DateTime.Now)
                {
                    VisitorTokenResponse visitorResponse = WebApiOperation.SendPost<int, VisitorTokenResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_CreateVisitorToken_URI, 7);

                    if (visitorResponse.Code == 0)
                    {
                       
                        HttpCookie cookie = new HttpCookie("visitortoken");
                        cookie.Values.Set("token", visitorResponse.Token);
                        cookie.Values.Set("date", visitorResponse.ExpireDate.ToString());
                        cookie.Expires = visitorResponse.ExpireDate;
                        filterContext.HttpContext.Response.Cookies.Add(cookie);
                    }


                }
                else
                {

                    //adamın visitor cookiesi var 
                    if (filterContext.HttpContext.Session["sepet"] == null)
                    {
                        //bu durumda remden sesionlar silinmiş
                        ShoppingCartResponse response = WebApiOperation.SendPost<string, ShoppingCartResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_SHOPPINGCARD_OFUSER, cok.Value);

                        if (response.Code == 0)
                        {
                            filterContext.HttpContext.Session["sepet"] = response;
                        }

                    }

                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }

}