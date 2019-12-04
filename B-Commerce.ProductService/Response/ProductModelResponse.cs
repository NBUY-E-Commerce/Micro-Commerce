using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class ProductModelResponse : BaseResponse
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();

        public PagingInfo PagingInfo { get; set; } = new PagingInfo();
    }
}
