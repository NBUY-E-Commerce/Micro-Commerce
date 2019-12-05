using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Product
{
    public class GetProductRequest
    {

       public int CategoryID { get; set; }
        public int Page { get; set; }

        public int Range { get; set; }

        public int BrandID { get; set; }

        public string Color { get; set; }
    }
}