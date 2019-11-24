using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductServiceApi.Models
{
    public class ProductProductImagesModel
    {
        public Product product { get; set; }
        public List<ProductImage> productImages { get; set; }
    }
}
