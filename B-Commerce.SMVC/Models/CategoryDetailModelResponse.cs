using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class CategoryDetailModelResponse : CommonResponse
    {
        public CategoryDetailModel Category { get; set; }
    }
}