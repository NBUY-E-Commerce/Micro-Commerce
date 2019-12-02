using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B_Commerce.SMVC.WebHelpers;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductSlider()
        {
            ProductModelResponse products = WebApiOperation.SendPost<int, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_INDEX_URI, 0);

            return PartialView("_PartialProductSlider", products.productModels);
        }
    }
}