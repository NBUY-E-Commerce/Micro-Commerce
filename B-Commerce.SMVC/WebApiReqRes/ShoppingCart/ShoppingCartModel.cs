using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.SMVC.WebApiReqRes.ShoppingCart
{
    public class ShoppingCartModel
    {
        public List<ShoppingCartProductModel> cardProduct { get; set; } = new List<ShoppingCartProductModel>();

        public decimal TotalPrice { get; set; }

        public decimal DiscountPrice { get; set; }

        public decimal LastPrice { get; set; }
    }

    public class ShoppingCartProductModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string MainImage { get; set; }

        public decimal Price { get; set; }

        public decimal CartDiscount { get; set; }


        public int ProductCount { get; set; }



    }
}
