using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class ProductModelResponse : CommonResponse
    {
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
        public Dictionary<string, int> ProductsColor { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> ProductsBrand { get; set; } = new Dictionary<string, int>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();

    }
}