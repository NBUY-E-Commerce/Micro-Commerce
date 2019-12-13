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
        public bool IsPayed { get; set; } = false;

        public virtual int PaymentTypeId { get; set; } = 1;
        public virtual PaymentType PaymentType { get; set;}

        public virtual ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; } = new List<ShoppingCartProduct>();
        public virtual Order Order { get; set; }
    }
}
