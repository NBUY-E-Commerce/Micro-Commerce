using B_Commerce.SMVC.Common;
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
        public ActionResult AddToCart(int productid, int count)
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
            var request = new AddShoppingCartRequest
            {
                Token = currentToken,
                ProductCount = count,
                ProductID = productid

            };


            //webapiye gidip addtocart(currenttoken,productid,count) çağırıcam
            ShoppingCartResponse response = WebApiOperation.SendPost<AddShoppingCartRequest, ShoppingCartResponse>(Constants.PRODUCT_API_BASE_URI, Constants.PRODUCT_API_SHOPPINGCARD_ADD, request);

            Session["sepet2"] = "maerhaba dunya";



            return View();
        }
    }
}