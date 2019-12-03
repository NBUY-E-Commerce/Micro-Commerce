using B_Commerce.SMVC.Areas.Admin.ActionFilters;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Areas.Admin.Controllers
{
    //altındaki tüm actionlar için bu filitre aktif olur
    [AutenticationFilter]
    public class CategoryController : Controller
    {

        [AuterizationFilter("Admin")]
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/Category
        [AuterizationFilter("Admin")]
        public ActionResult Get()
        {
            return View();
        }

        [AuterizationFilter("Admin", "User")]
        public ActionResult Add()
        {
            return View();
        }


      
    }
}