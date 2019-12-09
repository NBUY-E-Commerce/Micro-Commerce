using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class ProductSearchResponse:CommonResponse
    {
        public List<ProductModel> products { get; set; } = new List<ProductModel>();
    }
}