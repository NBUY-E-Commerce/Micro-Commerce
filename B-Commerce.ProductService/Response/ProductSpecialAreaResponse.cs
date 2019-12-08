using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class ProductSpecialAreaResponse:BaseResponse
    {
        public List<ProductSpecialAreaModels> ProductSpecialAreaModels { get; set; } = new List<ProductSpecialAreaModels>();
    }
}
