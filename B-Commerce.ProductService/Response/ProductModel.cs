using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductSpacialAreaTable> SpecialAreas { get; set; }
    }
}
