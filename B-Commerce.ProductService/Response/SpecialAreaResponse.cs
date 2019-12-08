using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class SpecialAreaResponse : BaseResponse
    {
        public List<SpecialAreaModel> SpecialAreas { get; set; } = new List<SpecialAreaModel>();
    }


    public class SpecialAreaModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
