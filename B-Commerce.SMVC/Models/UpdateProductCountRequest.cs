using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class UpdateProductCountRequest
    {
        public string Token { get; set; }
        public int ProductID { get; set; }
        public int NewCount { get; set; }
    }
}