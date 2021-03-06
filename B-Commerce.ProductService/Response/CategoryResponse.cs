﻿using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class CategoryResponse : BaseResponse
    {
        public Category Category { get; set; }
    }
    public class CategoryModelResponse : BaseResponse
    {
        public List<CategoryModel> Categories { get; set; }
    }
}
