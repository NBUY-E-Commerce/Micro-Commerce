using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Areas.Admin.Models
{
    public class ProductSpecialAreaModel
    {
        public int ProductID { get; set; }
        public int SpecialAreaID { get; set; }
        public string ProductName { get; set; }
        public string SpecialAreaName { get; set; }
    }
}