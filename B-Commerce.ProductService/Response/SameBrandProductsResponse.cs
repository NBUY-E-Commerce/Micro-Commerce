using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class SameBrandProductsResponse : BaseResponse
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
