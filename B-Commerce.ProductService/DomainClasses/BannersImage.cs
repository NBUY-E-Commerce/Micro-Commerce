using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class BannersImage :BaseEntity
    {

        //1 BİR PRODUCTI İŞARET EDER
        //2 İSE BİR CATEGORY İŞARET
        public int BannerType { get; set; }
        public int? RelatedID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
