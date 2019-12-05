using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.FilterHelper.Common;
using B_Commerce.SMVC.FilterHelper.Helpers.Abstract;
using System;
using System.Web;
using System.Web.Mvc;
using B_Commerce.Common.Security;

namespace B_Commerce.SMVC.FilterHelper.Helpers.Concrete
{
    public class UserHelper : IUserHelper
    {
      
        public void AddVisiterCookie(ActionExecutingContext filterContext, string token)
        {
            HttpCookie httpCookie = new HttpCookie(VT_Constants.VT_COOKIE, token);
            httpCookie.Expires = DateTime.Today.AddDays(VT_Constants.VT_EXPIRE_DATE);
            filterContext.HttpContext.Request.Cookies.Set(httpCookie);
        }

        public string CreateToken()
        {
            throw new NotImplementedException();
        }

        public HttpCookie GetVisiterCookie(ActionExecutingContext filterContext, string CookieName)
        {
            return filterContext.HttpContext.Request.Cookies[CookieName];
        }


        public SystemUser IsThereCurrentToken()
        {
            return SystemUser.CurrentUser;
        }

        public void KillVisiterCookie(ActionExecutingContext filterContext, string CookieName)
        {
            if (filterContext.HttpContext.Request.Cookies[CookieName] != null)
            {
                filterContext.HttpContext.Request.Cookies[CookieName].Expires = DateTime.Now.AddDays(-1);
            }

          
        }
        private Token CreateToken(double expireDay = 1)
        {
            string token = RandomGenerator.Generate(45);
            return new Token
            {
                TokenText = token,
                EndDate = DateTime.Now.AddDays(expireDay),
            };
        }
    }
}