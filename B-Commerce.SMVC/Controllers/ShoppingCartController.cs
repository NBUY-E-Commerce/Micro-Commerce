using B_Commerce.SMVC.Common;
using B_Commerce.SMVC.WebApiReqRes;
using B_Commerce.SMVC.WebApiReqRes.Autentication.Login;
using B_Commerce.SMVC.WebApiReqRes.ShoppingCart;
using B_Commerce.SMVC.WebHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                currentToken = Request.Cookies["visitortoken"].Value;
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
    }
}