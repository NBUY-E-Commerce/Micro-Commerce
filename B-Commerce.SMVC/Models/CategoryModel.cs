﻿using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class CategoryModel:CommonResponse
    {
        public int ID { get; set; }

        public bool HasSubCategory { get; set; }
        public string Name { get; set; }

        public List<CategoryModel> SubCategories { get; set; }

        


    }
}