using B_Commerce.SMVC.Common;
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

            //webapiye gidip addtocart(currenttoken,productid,count) çağırıcam



            return View();
        }
    }
}