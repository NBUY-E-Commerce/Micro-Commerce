using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductService.Api.DTO
{
    public class SpecialAreaDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
