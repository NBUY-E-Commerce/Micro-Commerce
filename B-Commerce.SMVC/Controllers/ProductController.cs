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
        public ActionResult ProductSlider(int? a)
        {
            GetSpecialProductRequest request = new GetSpecialProductRequest();
            if (a == null)
            {
                request.Count = 1;
                request.PageNumber = 1;
                request.SpacialID = 3;


            }
            else
            {
                request.Count = (int)a + 1;
                request.PageNumber = 1;
                request.SpacialID = 3;

            }

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
            List<ProductModel> products = new List<ProductModel>();//kullanılma ihtimali olduğu için duruyor
            ProductModelResponse response = new ProductModelResponse();// product detaile göre şekillenicek.
            GetProductRequest request = new GetProductRequest();
            request.CategoryID = CategoryID;
            request.Range = 5;
            // System.Random rnd = new System.Random(); Productın tekil çekilmesi veya product service eklenmesi gerekebilir.
            response = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS, request);
            products = response.Products;
            return PartialView("_PartialMoreProducts", products);
        }
        public ActionResult ProductDetail(int ID)
        {
            B_Commerce.SMVC.Areas.Admin.Models.GetProductModelResponse Response = WebApiOperation.SendPost<int, B_Commerce.SMVC.Areas.Admin.Models.GetProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTBYID, ID);
            if (Response.GetProductModel == null)
            {
                return PartialView("Error", "ErrorModel"); // ??
            }

            return PartialView("_PartialProductDetail", Response.GetProductModel);
        }

        public ActionResult Detail(int ID)
        {
            Areas.Admin.Models.GetProductModelResponse Response = WebApiOperation.SendPost<int, Areas.Admin.Models.GetProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTBYID, ID);
            if (Response.GetProductModel == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(Response.GetProductModel);
        }

        public ActionResult SameBrandProduct(int brandID)
        {

            ProductModelResponse response = WebApiOperation.SendPost<int, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GET_SAME_BRAND_PRODUCTS, brandID);

            return PartialView("_PartialSameBrandProduct", response.Products);

        }
    }
}