using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes.Product;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Controllers
{

    public class CategoryController : Controller
    {

        public ActionResult Products(int categoryID, string name)
        {
            int page = 1, range = 10;


            if (Request.QueryString["page"] != null) page = Convert.ToInt32(Request.QueryString["page"]);
            if (Request.QueryString["range"] != null) range = Convert.ToInt32(Request.QueryString["range"]);
            string color = Request.QueryString["color"] == null ? string.Empty : Request.QueryString["color"];
            int brandid = Request.QueryString["brand"] == null ? 0 : Convert.ToInt32(Request.QueryString["brand"]);

            GetProductRequest request = new GetProductRequest
            {
                CategoryID = categoryID,
                Page = page,
                Range = range,
                BrandID = brandid,
                Color = color

            };
            ViewBag.name = name;
            ProductModelResponse categoryChangeResponse = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS, request);

            ViewBag.range = range;

            if (categoryChangeResponse.Code != 0) return RedirectToAction("General", "Error");

            return View(categoryChangeResponse);
        }


        // GET: Category
        public ActionResult MainCategoryPartial()
        {
            CategoryModelResponse categoryChangeResponse = WebApiOperation.SendPost<int, CategoryModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_INDEX_URI, 0);

            return PartialView("_PartialTopBarMenu", categoryChangeResponse);

        }

        [HttpPost]
        public ActionResult CategorySearchAjax(string param)
        {
            CategoryModelResponse categoryChangeResponse = WebApiOperation.SendPost<int, CategoryModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_INDEX_URI, 0);
            //List<Models.Product> products = MockDb.products.Where(t => t.Name.Contains(param)).ToList();


            List<CategoryModel> res = new List<CategoryModel>();

            res = categoryChangeResponse.categories.Where(t => t.Name.Contains(param)).ToList();
            //return PartialView("_PartialProductList", products);
            return PartialView("_PartialProductSearch", res);

        }







    }
}