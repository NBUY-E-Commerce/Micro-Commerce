using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.FilterHelper.Common;
using B_Commerce.SMVC.FilterHelper.Helpers.Abstract;
using B_Commerce.SMVC.FilterHelper.Helpers.Concrete;
using B_Commerce.SMVC.FilterHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.FilterHelper.Filters
{
    public class VisiterTokenAttribute : ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            VisiterToken(filterContext);
            base.OnActionExecuting(filterContext);

        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public void VisiterToken(ActionExecutingContext filterContext) {
           
            UserHelper _userHelper = new UserHelper();
            SystemUser systemUser = _userHelper.IsThereCurrentToken();
            HttpCookie currentCookie = _userHelper.GetVisiterCookie(filterContext, VT_Constants.VT_COOKIE);

            if (systemUser == null)
            {
                if (currentCookie == null)
                {

                    VisitorTokenRequest token = _userHelper.GetVisiterToken(VT_Constants.VT_EXPIRE_DATE);
                    _userHelper.AddVisiterCookie(filterContext, token.Token);
                }
            }
            else
            {
                _userHelper.KillVisiterCookie(filterContext, VT_Constants.VT_COOKIE);
            }
        }
    }
}