﻿using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Areas.Admin.Models
{
 
    public class GetProductModelResponse : CommonResponse
    {
        public ProductModel GetProductModel { get; set; }
    }
}