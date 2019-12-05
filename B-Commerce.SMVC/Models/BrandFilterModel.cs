using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class BrandFilterModel
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }

        public int ProductCount { get; set; }
      
    }
}