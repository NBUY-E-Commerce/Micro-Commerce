using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Areas.Admin.ActionFilters
{
    public class AutenticationFilter : ActionFilterAttribute
    {
      


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //daha methoda gitmeden calısır-->burada işilemi durdurabilirim
            //giden requestı değiştirebilirim

            if (filterContext.RequestContext.HttpContext.Session["useradmin"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
            }
            else
            {

                base.OnActionExecuting(filterContext);
            }

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //actionın  içindeki işlemler yapıldı ve geriye donus yapılıdıgında burası devreye girer
            base.OnActionExecuted(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //result birimine girilildi
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // result birimindeb cıkıldı artıkelimizde geri donecek sonucun son halivar
            base.OnResultExecuted(filterContext);
        }




    }
}