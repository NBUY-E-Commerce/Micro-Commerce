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
            GetProductRequest request = new GetProductRequest
            {
                CategoryID = CategoryID,
                Range = 5
            };
            ProductModelResponse response = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETRANDOMPRODUCTS, request);
            if (response.Code != 0)
            {
                ViewBag.error = response.Message;
                return PartialView("_PartialMoreProducts");
            }
            return PartialView("_PartialMoreProducts", response.Products);
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
    }
}