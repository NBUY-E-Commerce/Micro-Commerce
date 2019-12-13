using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class Order : BaseEntity
    {
        public DateTime CargoDate { get; set; } = DateTime.Now;
        public DateTime? CargoArriveDate { get; set; }
        public bool? CargoArrived { get; set; } = false;


        public int PaymentTypeId { get; set; } = 1;
        public virtual PaymentType PaymentType { get; set; }

        public int ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }


    }
}
