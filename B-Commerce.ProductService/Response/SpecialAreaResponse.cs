﻿using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class SpecialAreaResponse : BaseResponse
    {
        public List<SpacialArea> SpecialAreas { get; set; }
    }
}