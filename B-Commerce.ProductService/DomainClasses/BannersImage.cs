using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class BannersImage :BaseEntity
    {
        public int? ProductID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
