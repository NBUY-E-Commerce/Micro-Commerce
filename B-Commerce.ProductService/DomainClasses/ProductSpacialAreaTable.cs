using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class ProductSpacialAreaTable
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int SpacialAreaID { get; set; }
        public SpacialArea SpacialArea { get; set; }
    }
}
