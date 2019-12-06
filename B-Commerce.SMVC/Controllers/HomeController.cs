using B_Commerce.SMVC.FilterHelper.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Controllers
{
    [VisiterToken]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

    }
}