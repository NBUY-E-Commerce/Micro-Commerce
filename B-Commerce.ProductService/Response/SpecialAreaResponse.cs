using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class SpecialAreaResponse : BaseResponse
    {
        public List<SpacialArea> SpecialAreas { get; set; } = new List<SpacialArea>();
    }

    public class SpecialAreaModelResponse : BaseResponse
    {

        public List<SpecialAreaModel> SpecialAreaModels { get; set; } = new List<SpecialAreaModel>();
    }
}
