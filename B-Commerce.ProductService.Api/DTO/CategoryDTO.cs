using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductService.Api.DTO
{
    public class CategoryDTO
    {
        public int? ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; } = true;
        public int? MasterCategoryID { get; set; }
    }
}
