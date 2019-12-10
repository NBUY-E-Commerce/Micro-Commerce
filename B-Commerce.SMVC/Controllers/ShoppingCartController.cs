using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes.Autentication.Login;
using B_Commerce.SMVC.WebApiReqRes.ShoppingCart;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace B_Commerce.SMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public JsonResult AddToCart(int productid, int count)
        {
            string currentToken = "";
            if (SystemUser.CurrentUser != null)
            {
                currentToken = SystemUser.CurrentUser.Token;
            }
            else
            {
                currentToken = Request.Cookies["visitortoken"].Values["token"];
            }

            CheckTokenResponse responseToken = WebApiOperation.SendPost<string, CheckTokenResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_CHECKTOKEN_URI, currentToken);

            if (responseToken.Code != 0)//token süresi geçmiş
            {
                //token verification error!!
                throw new Exception();
            }

            var request = new AddShoppingCartRequest
            {
                Token = currentToken,
                ProductCount = count,
                ProductID = productid
            };

            //webapiye gidip addtocart(currenttoken,productid,count) çağırıcam
            ShoppingCartResponse response = WebApiOperation.SendPost<AddShoppingCartRequest, ShoppingCartResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_SHOPPINGCARD_ADD, request);

            if (response.Code == 0)
                Session["sepet"] = response;

            return Json(response);
        }

        public ActionResult Details()
        {
            var model = (ShoppingCartResponse)Session["sepet"];
            return View(model);
        }

        public JsonResult UpdateProductCountOfShoppingCart(List<UpdateProductCountRequest> UpdateProductCounts)
        {
            return Json(1);
            //string currentToken = "";
            //if (SystemUser.CurrentUser != null)
            //{
            //    currentToken = SystemUser.CurrentUser.Token;
            //}
            //else
            //{
            //    currentToken = Request.Cookies["visitortoken"].Values["token"];
            //}

            //CheckTokenResponse responseToken = WebApiOperation.SendPost<string, CheckTokenResponse>(Constants.LOGIN_API_BASE_URI, Constants.LOGIN_API_CHECKTOKEN_URI, currentToken);

            //if (responseToken.Code != 0)
            //{
            //    throw new Exception();
            //}

            //foreach (UpdateProductCountRequest item in UpdateProductCounts.UpdateProductCounts)
            //{
            //    item.Token = currentToken;
            //}

            ////webapiye gidip addtocart(currenttoken,productid,count) çağırıcam
            //ShoppingCartResponse response = WebApiOperation.SendPost<UpdateProductCountListRequest, ShoppingCartResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_SHOPPINGCARD_UPDATE, request);

            //if (response.Code == 0)
            //    Session["sepet"] = response;

            //return Json(response);
        }
    }
}