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

        [HttpPost]
        public JsonResult GetCategoryByMasterID(int id)
        {
            CategoryModelResponse categoryChangeResponse = WebApiOperation.SendPost<int, CategoryModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_INDEX_URI, id);

            return Json(categoryChangeResponse);

        }

        [HttpPost]
        public JsonResult GetCategoryByID(int id)
        {
            CategoryDetailModelResponse response = WebApiOperation.SendPost<int, CategoryDetailModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETBYID_CATEGORY, id);

            return Json(response);

        }


        [HttpPost]
        public JsonResult GetCategoryShortInfo()
        {
            CategoryShortInfoResponse response = WebApiOperation.SendPost<int, CategoryShortInfoResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GET_CATEGORY_SHORT_INFO, 1);

            return Json(response);

        }
        

    }
}