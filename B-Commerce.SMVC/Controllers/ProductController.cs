using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using B_Commerce.SMVC.WebHelpers;
using System.Web.Mvc;
using B_Commerce.SMVC.WebApiReqRes.Product;

namespace B_Commerce.SMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductSlider()
        {
            GetSpecialProductRequest request = new GetSpecialProductRequest
            {

                Count = 5,
                PageNumber = 1,
                SpacialID = 3//slider ürünler için ID
            };

            ProductModelResponse response = WebApiOperation.SendPost<GetSpecialProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GET_SPECIAL_PRODUCTS, request);

            return PartialView("_PartialProductSlider", response);

        }

        public ActionResult Banners()
        {
            BannerModelResponse bannerResponse = WebApiOperation.SendPost<object, BannerModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_BANNER_URI, null);

            if (bannerResponse.Code != 0)
            {
                ViewBag.error = bannerResponse.Message;
                return PartialView("_PartialBanner");
            }

            return PartialView("_PartialBanner", bannerResponse.BannersImages);
        }

        public ActionResult MoreProducts(int CategoryID)
        {
            List<ProductModel> products = new List<ProductModel>();
            ProductModelResponse response = new ProductModelResponse();
            GetProductRequest request = new GetProductRequest();
            request.CategoryID = CategoryID;
            request.Range = 5;
            // System.Random rnd = new System.Random(); Productın tekil çekilmesi veya product service eklenmesi gerekebilir.
                response = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS, request);
                products=response.Products;
            return PartialView("", products);
        }
    }
}