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
            int page = 1, range = 5;
            if (Request.QueryString["page"] != null)
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }

            if (Request.QueryString["range"] != null)
            {

                range = Convert.ToInt32(Request.QueryString["range"]);
            }

            GetProductRequest request = new GetProductRequest
            {
                CategoryID = categoryID,
                Page = page,
                Range = range

            };
            ViewBag.name = name;
            ProductModelResponse categoryChangeResponse = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS, request);

            return View(categoryChangeResponse);
        }
        public ActionResult GetProductsColor()
        {
            string Color = "";
            int categoryId = 0;
            categoryId = Convert.ToInt32(Request.Url.Segments[2].Substring(0, Request.Url.Segments[2].Length - 1));
            if (Request.QueryString["Key"] != null)
            {
                Color = Request.QueryString["Key"];
            }

            ProductModelResponse productModelResponse = WebApiOperation.SendPost<object, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS_COLOR, new { categoryID = categoryId, color = Color });

            return View(productModelResponse);
        }
        public ActionResult ProductsColor()
        {
            int categoryId = 0;
            categoryId = Convert.ToInt32(Request.Url.Segments[2].Substring(0, Request.Url.Segments[2].Length - 1));
            string categoryName = Request.Url.Segments[3].Substring(0, Request.Url.Segments[3].Length);

            ProductModelResponse productModelResponse = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_PRODUCTS_COLOR, new GetProductRequest { CategoryID = categoryId });

            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryName = categoryName;

            return PartialView("_PartialProductsColor", productModelResponse);
        }
        public ActionResult ProductsBrand()
        {
            int categoryId = 0;
            categoryId = Convert.ToInt32(Request.Url.Segments[2].Substring(0, Request.Url.Segments[2].Length - 1));
            string categoryName = Request.Url.Segments[3].Substring(0, Request.Url.Segments[3].Length);

            ProductModelResponse productModelResponse = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS_BRAND, new GetProductRequest { CategoryID = categoryId });

            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryName = categoryName;

            return PartialView("_PartialProductsBrand", productModelResponse);
        }
        public ActionResult GetProductsBrand(int categoryID, string Brand)
        {
            int categoryId = 0;
            categoryId = Convert.ToInt32(Request.Url.Segments[2].Substring(0, Request.Url.Segments[2].Length - 1));
            string categoryName = Request.Url.Segments[3].Substring(0, Request.Url.Segments[3].Length);

            ProductModelResponse productModelResponse = WebApiOperation.SendPost<object, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS_BRAND, new { CategoryID = categoryId, brand = Brand });

            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryName = categoryName;

            return View(productModelResponse);
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