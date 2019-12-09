using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    class ProductSearchResponse : BaseResponse
    {

        public List<ProductModel> products { get; set; } = new List<ProductModel>();

    }
}
