using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.FilterHelper.Common;
using B_Commerce.SMVC.FilterHelper.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.FilterHelper.Filters
{
    public class VisiterTokenAttribute: ActionFilterAttribute
    {
        private IUserHelper _userHelper;
        public VisiterTokenAttribute(IUserHelper userHelper) {
            _userHelper = userHelper;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Token varmı--->varsa devam
            //yoksa--->>visitor token varmı-->>varsa devam
            //yoksa git Loginden token al cookie ye at
            SystemUser systemUser = _userHelper.IsThereCurrentToken();
            HttpCookie currentCookie = _userHelper.GetVisiterCookie(filterContext,VT_Constants.VT_COOKIE);
            if (systemUser == null)
            {
                if (currentCookie == null)
                {
                    //create visiter suer
                    //filterConectext
                    //string token = _userHelper.CreateToken();
                    //_userHelper.AddVisiterCookie(filterContext, token);
                }
            }
            else {
                _userHelper.KillVisiterCookie(filterContext,VT_Constants.VT_COOKIE);
            }
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
    }
}