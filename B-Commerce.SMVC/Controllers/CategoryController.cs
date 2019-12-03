using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
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
        // GET: Category
        public ActionResult Index()
        {
            CategoryModelResponse categoryChangeResponse = WebApiOperation.SendPost<int, CategoryModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_INDEX_URI, 0);

            return PartialView("_PartialTopBarMenu",categoryChangeResponse);

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