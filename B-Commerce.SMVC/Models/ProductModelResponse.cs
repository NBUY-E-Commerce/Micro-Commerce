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
        public List<BrandFilterModel> ProductsBrand { get; set; } = new List<BrandFilterModel>();
        public PagingInfo PagingInfo { get; set; } = new PagingInfo();

        public string CategoryDescription { get; set; }

    }
}