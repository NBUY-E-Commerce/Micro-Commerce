using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class ProductModelResponse : BaseResponse
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public Dictionary<string, int> ProductsColor { get; set; } = new Dictionary<string, int>();
        public List<BrandFilterModel> ProductsBrand { get; set; } = new List<BrandFilterModel>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
    }
}
