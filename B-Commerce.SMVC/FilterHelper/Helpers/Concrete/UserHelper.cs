using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.FilterHelper.Common;
using B_Commerce.SMVC.FilterHelper.Helpers.Abstract;
using System;
using System.Web;
using System.Web.Mvc;

using B_Commerce.SMVC.FilterHelper.Model;
using B_Commerce.SMVC.WebHelpers;
using System.Net.Http;
using System.Threading.Tasks;

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

        public VisitorTokenRequest GetVisiterToken(int ExpireTime) {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Constants.LOGIN_API_BASE_URI);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            VisitorTokenRequest response = new VisitorTokenRequest();
            
            Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync(Constants.LOGIN_API_CREATE_VISITOR_TOKEN_URI, ExpireTime);
            if (httpResponse.Result.IsSuccessStatusCode)
            {
                return httpResponse.Result.Content.ReadAsAsync<VisitorTokenRequest>().Result;
            }

            try
            {
                response = httpResponse.Result.Content.ReadAsAsync<VisitorTokenRequest>().Result;
            }
            catch (Exception ex)
            {


                return new VisitorTokenRequest
                {
                    Token = "-1",
                    Username = null,
                };
            }
            return null;
        }


    }

}