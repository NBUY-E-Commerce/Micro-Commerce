﻿using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class CategoryModelResponse:CommonResponse
    {
        public List<CategoryModel> categories { get; set; } = new List<CategoryModel>();

   

    }
}