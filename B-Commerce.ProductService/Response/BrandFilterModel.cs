using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class BrandFilterModel
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public int ProductCount { get; set; }
    }
}
