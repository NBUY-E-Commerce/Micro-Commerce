using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class BannerResponse : BaseResponse
    {
        public List<BannersImage> BannersImages { get; set; } = new List<BannersImage>();
    }
    public class BannerModelResponse : BaseResponse
    {

        public List<BannerModel> BannerModels { get; set; } = new List<BannerModel>();
    }
}
