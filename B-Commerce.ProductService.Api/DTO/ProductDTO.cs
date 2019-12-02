using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductService.Api.DTO
{
    public class ProductDTO
    {
        public int? ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int AvailableCount { get; set; }
        public bool isActive { get; set; } = true;
        public int CategoryID { get; set; }
        public string ImageUrl { get; set; }
    }
}
