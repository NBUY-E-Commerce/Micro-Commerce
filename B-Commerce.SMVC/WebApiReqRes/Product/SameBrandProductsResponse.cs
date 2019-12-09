using B_Commerce.SMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Product
{
    public class SameBrandProductsResponse : CommonResponse
    {
        public List<ProductModel> Products { get; set; }
    }
}