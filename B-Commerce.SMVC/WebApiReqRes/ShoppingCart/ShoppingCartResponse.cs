
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.SMVC.WebApiReqRes.ShoppingCart
{
    public class ShoppingCartResponse:CommonResponse
    {
        public ShoppingCartModel shoppingCartModel { get; set; } = new ShoppingCartModel();
    }
}
