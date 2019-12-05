using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductService.Api.DTO
{
    public class ShoppingCartProductDTO
    {
        public int ShoppingCartID { get; set; }


        public int ProductID { get; set; }
        public int ProductCount { get; set; }


        public virtual Product Product { get; set; } = new Product();
        public virtual ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();

    }
}
