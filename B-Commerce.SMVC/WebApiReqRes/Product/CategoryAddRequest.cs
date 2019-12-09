﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Product
{
    public class CategoryAddRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; } = true;
        public int? MasterCategoryID { get; set; }
    }
}