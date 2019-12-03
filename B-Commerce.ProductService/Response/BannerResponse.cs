using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class BannerResponse : BaseResponse
    {
        public List<BannersImage> BannersImages { get; set; }
    }
    public class BannerModelResponse : BaseResponse
    {
        
        public List<BannersImage> BannersImages { get; set; }
    }
}
