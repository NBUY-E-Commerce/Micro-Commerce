using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class PaymentType:BaseEntity
    {
        public string PaymentTypeName { get; set; }
        public virtual  Order Order { get; set; }
    }
}
