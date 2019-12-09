using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class ShoppingCartProduct : BaseEntity
    {

        public int ShoppingCartID { get; set; }
        public int ProductID { get; set; }
        public int ProductCount { get; set; }

        public virtual Product Product { get; set; } 
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
