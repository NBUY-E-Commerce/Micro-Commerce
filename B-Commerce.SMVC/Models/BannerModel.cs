using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class BannerModel:CommonResponse
    {

        public int BannerType { get; set; }
        public int? RelatedID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

    }
}