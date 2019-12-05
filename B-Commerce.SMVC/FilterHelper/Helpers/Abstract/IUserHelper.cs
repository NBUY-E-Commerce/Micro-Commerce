using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.FilterHelper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.FilterHelper.Helpers.Abstract
{
    public interface IUserHelper
    {
        SystemUser IsThereCurrentToken();
        void AddVisiterCookie(ActionExecutingContext filterContext,string token);
        HttpCookie GetVisiterCookie(ActionExecutingContext filterContext, string tokenName);
        void KillVisiterCookie(ActionExecutingContext filterContext, string CookieName);
    }
}
