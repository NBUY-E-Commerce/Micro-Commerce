
using B_Commerce.SMVC.Areas.Admin.Models;
using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes;
using B_Commerce.SMVC.WebApiReqRes.Product;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductModel = B_Commerce.SMVC.Models.ProductModel;

namespace B_Commerce.SMVC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Add()
        {
            //productservisten categorylistesini al


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(ProductModel productModel)
        {
            //productservisten categorylistesini al
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (Request.Files.Count > 0)
            {
                //resim var
                string path = Server.MapPath("/");

                if (!Directory.Exists(path + "/ProductImage"))
                {
                    Directory.CreateDirectory(path + "/ProductImage");
                }

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    string imagePath = path + "/ProductImage/" + Request.Files[i].FileName;
                    Request.Files[i].SaveAs(imagePath);
                    productModel.ProductImages.Add("/ProductImage/" + Request.Files[i].FileName);
                }


            }

            CommonResponse categoryChangeResponse = WebApiOperation.SendPost<ProductModel, CommonResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_ADD, productModel);

            if (categoryChangeResponse.Code != 0)
            {
                ViewBag.error = categoryChangeResponse.Message;
                return View();

            }
            ViewBag.error = MyResource.Resource.General_Success;
            return View();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Update(int ID)
        {
            B_Commerce.SMVC.Areas.Admin.Models.GetProductModelResponse Response = WebApiOperation.SendPost<int, B_Commerce.SMVC.Areas.Admin.Models.GetProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTBYID, ID);
            if (!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Product/Add.cshtml", Response.GetProductModel);
            }

            if (Request.Files.Count > 0)
            {
                //resim var
                string path = Server.MapPath("/");

                if (!Directory.Exists(path + "/ProductImage"))
                {
                    Directory.CreateDirectory(path + "/ProductImage");
                }

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    string imagePath = path + "/ProductImage/" + Request.Files[i].FileName;
                    Request.Files[i].SaveAs(imagePath);
                    Response.GetProductModel.ImageUrls.Add("/ProductImage/" + Request.Files[i].FileName);
                }
            }

            if (Response.Code != 0)
            {
                ViewBag.error = Response.Message;
                return View("~/Areas/Admin/Views/Product/Add.cshtml", Response.GetProductModel);
            }

            ViewBag.error = MyResource.Resource.General_Success;
            return View("~/Areas/Admin/Views/Product/Add.cshtml", Response.GetProductModel);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(ProductModel productmodel)
        {
            //productmodel.ID = Request;
            CommonResponse Response = WebApiOperation.SendPost<ProductModel, CommonResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_UPDATE, productmodel);

            B_Commerce.SMVC.Areas.Admin.Models.GetProductModelResponse product = WebApiOperation.SendPost<int, B_Commerce.SMVC.Areas.Admin.Models.GetProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTBYID, productmodel.ID);

            if (Response.Code != 0)
            {
                ViewBag.error = Response.Message;
                return View("~/Areas/Admin/Views/Product/Add.cshtml", product.GetProductModel);
            }

            ViewBag.error = MyResource.Resource.General_Success;
            return View("~/Areas/Admin/Views/Product/Add.cshtml", product.GetProductModel);
        }


        public ActionResult GetProductList()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetProductListJson()
        {

            GetProductRequest request = new GetProductRequest
            {
                CategoryID = 0,
                Page = 1,
                Range = 20,
                BrandID = 0,
                Color = ""

            };

            //servis kısmının model response kısmı farklı.
            ProductModelResponse productModelResponse = WebApiOperation.SendPost<GetProductRequest, ProductModelResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETPRODUCTS, request);
            if (productModelResponse.Code == Constants.LOGIN_RESPONSE_SUCCESS)
            {
                return Json(productModelResponse.Products);
            }
            ViewBag.Error = productModelResponse.Message;
            return Json("");
        }
        public ActionResult SpecialArea()
        {
            B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaModel specialArea = new Models.SpecialAreaModel();
            return View(specialArea);
        }
        [HttpPost]
        public ActionResult SpecialArea(B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaModel specialAreaModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SpecialAreaResponse specialAreaResponse = WebApiOperation.SendPost<B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaModel, SpecialAreaResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_SPECIAL_AREA, specialAreaModel);

            if (specialAreaResponse.Code != 0)
            {
                ViewBag.error = specialAreaResponse.Message;
                return View();

            }
            ViewBag.error = MyResource.Resource.General_Success;
            return View();

        }

        public ActionResult GetSpecialAreas()
        {
            SpecialAreaResponse specialAreaResponse = WebApiOperation.SendPost<object, SpecialAreaResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETSPECIAL_AREA, null);

            if (specialAreaResponse.Code != 0)
            {
                ViewBag.error = specialAreaResponse.Message;
                return PartialView("_PartialSpacialArea");
            }

            return PartialView("_PartialSpacialArea", specialAreaResponse.SpecialAreas);
        }
        public ActionResult SpecialAreaUpdate(int ID)
        {
            B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaResponse Response = WebApiOperation.SendPost<int, B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETSPECIAL_AREA_BYID, ID);
            if (!ModelState.IsValid)
            {
                return View("~/Areas/Admin/Views/Product/SpecialArea.cshtml", Response.SpecialAreas[0]);
            }

            if (Response.Code != 0)
            {
                ViewBag.error = Response.Message;
                return View("~/Areas/Admin/Views/Product/SpecialArea.cshtml", Response.SpecialAreas[0]);
            }

            ViewBag.error = MyResource.Resource.General_Success;
            return View("~/Areas/Admin/Views/Product/SpecialArea.cshtml", Response.SpecialAreas[0]);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SpecialAreaUpdate(SpecialAreaModel specialAreaModel)
        {
            B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaResponse Response = WebApiOperation.SendPost<SpecialAreaModel, B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_UPDATESPECIAL_AREA, specialAreaModel);

            B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaResponse special = WebApiOperation.SendPost<int, B_Commerce.SMVC.Areas.Admin.Models.SpecialAreaResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_GETSPECIAL_AREA_BYID,specialAreaModel.ID);

            if (Response.Code != 0)
            {
                ViewBag.error = Response.Message;
                return View("~/Areas/Admin/Views/Product/SpecialArea.cshtml", special.SpecialAreas[0]);
            }

            ViewBag.error = MyResource.Resource.General_Success;
            return View("~/Areas/Admin/Views/Product/SpecialArea.cshtml", special.SpecialAreas[0]);
        }
      
        public ActionResult DeleteSpecialAreaByID(int ID)
        {
           CommonResponse Response = WebApiOperation.SendPost<int, CommonResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_DELETE_SPECIAL_AREA, ID);

            return View("~/Areas/Admin/Views/Product/SpecialArea.cshtml");
        }

    }
}