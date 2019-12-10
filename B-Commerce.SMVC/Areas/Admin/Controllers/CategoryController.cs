using B_Commerce.SMVC.Areas.Admin.ActionFilters;
using B_Commerce.SMVC.Areas.Admin.Models;
using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes;
using B_Commerce.SMVC.WebApiReqRes.Product;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Areas.Admin.Controllers
{
    //altındaki tüm actionlar için bu filitre aktif olur
    //[AutenticationFilter]
    public class CategoryController : Controller
    {

        public ActionResult Index()
        {
            AdminCategoryIndexModel adminCategoryIndexModel = new AdminCategoryIndexModel();
            CategoryModelResponse categoryChangeResponse = WebApiOperation.SendPost<int, CategoryModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_INDEX_URI, 0);
            adminCategoryIndexModel.CategoryModelResponse = categoryChangeResponse;
            return View(adminCategoryIndexModel);
        }

        [HttpPost]
        public ActionResult Add(CategoryAddRequest request)
        {
            request.isActive = true;
            AdminCategoryIndexModel adminCategoryIndexModel = new AdminCategoryIndexModel();
            if (!ModelState.IsValid)
            {
                adminCategoryIndexModel.CategoryAddRequest = request;
                return RedirectToAction("Index", "Category", adminCategoryIndexModel);
            }
            CommonResponse addResponse = WebApiOperation.SendPost<CategoryAddRequest, CommonResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_ADD_CATEGORY, request);

            TempData["ResponseCode"] = addResponse.Code;
            TempData["ResponseMessage"] = addResponse.Message;
            //mesajlar sayfaya donulecek
            return RedirectToAction("Index", "Category", adminCategoryIndexModel);
        }


        [HttpPost]
        public ActionResult Update(CategoryUpdateRequest request)
        {
            //doldur
            CommonResponse updateResponse = WebApiOperation.SendPost<CategoryUpdateRequest, CommonResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_UPDATE_CATEGORY, request);
            TempData["ResponseCode"] = updateResponse.Code;
            TempData["ResponseMessage"] = updateResponse.Message;
            return RedirectToAction("Index", "Category");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            //doldur
            CommonResponse deleteResponse = WebApiOperation.SendPost<int, CommonResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_DELETE_CATEGORY, ID);
            TempData["ResponseCode"] = deleteResponse.Code;
            TempData["ResponseMessage"] = deleteResponse.Message;
            return RedirectToAction("Index", "Category");
        }

        public PartialViewResult AddFormPartial()
        {
            CategoryShortInfoResponse response1 = WebApiOperation.SendPost<int, CategoryShortInfoResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GET_CATEGORY_SHORT_INFO, 1);
            ViewData["shortInfoCategories"] = response1.CategoryShortInfos;

            return PartialView("_PartialAddCategory");
        }

        public PartialViewResult UpdateFormPartial(int id)
        {
           
            CategoryShortInfoResponse response1 = WebApiOperation.SendPost<int, CategoryShortInfoResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GET_CATEGORY_SHORT_INFO, 1);
            ViewData["shortInfoCategories"] = response1.CategoryShortInfos;

            if (id == 0)
            {
                return PartialView("_PartialUpdateCategory", null);
            }


            CategoryDetailModelResponse response = WebApiOperation.SendPost<int, CategoryDetailModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETBYID_CATEGORY, id);
            return PartialView("_PartialUpdateCategory", response.Category);
        }





    }
}