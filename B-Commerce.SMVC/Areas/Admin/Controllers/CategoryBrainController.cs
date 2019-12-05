using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Areas.Admin.Controllers
{
    public class CategoryBrainController : Controller
    {
        // GET: Admin/CategoryBrain
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllCategories()
        {

            CategoryModelResponse categoryChangeResponse = WebApiOperation.SendPost<int, CategoryModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_INDEX_URI, 0);

            return Json(categoryChangeResponse,JsonRequestBehavior.AllowGet);

        }
    }
}