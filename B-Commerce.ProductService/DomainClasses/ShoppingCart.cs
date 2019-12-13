using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
   public class ShoppingCart : BaseEntity
    {
      
        public int UserID { get; set; }
        public string Token { get; set; }

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; } = new List<ShoppingCartProduct>();
        public virtual Order Order { get; set; }
    }
}
