using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Areas.Admin.Models
{
    public class SpecialAreaResponse :CommonResponse
    {
        public List<SpecialAreaModel> SpecialAreas { get; set; } = new List<SpecialAreaModel>();
    }
}