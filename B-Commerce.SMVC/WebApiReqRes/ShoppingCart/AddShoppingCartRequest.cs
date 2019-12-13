using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.ShoppingCart
{
    public class AddShoppingCartRequest
    {

        public string Token { get; set; }
        public int ProductID { get; set; }
        public int ProductCount { get; set; }
        public int UserID { get; set; }

    }
}