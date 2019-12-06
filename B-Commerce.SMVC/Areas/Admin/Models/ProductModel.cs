using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Areas.Admin.Models
{
    public class ProductModel
    {
        public int? ID { get; set; }

        [Display(ResourceType = typeof(B_Commerce.SMVC.MyResource.Resource), Name = "Product_ProductName")]
        public string ProductName { get; set; }

        [Display(ResourceType = typeof(B_Commerce.SMVC.MyResource.Resource), Name = "Product_Description")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int AvailableCount { get; set; }
        public bool isActive { get; set; } = true;
        public int CategoryID { get; set; }
        public string Brand { get; set; }
        public int BrandID { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}