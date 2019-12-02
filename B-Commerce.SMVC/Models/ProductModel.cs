using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class ProductModel
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
        public bool IsInSlider { get; set; }
        public bool IsInNew { get; set; }
        public bool IsInSale { get; set; }
        public bool IsInGift { get; set; }
    }
}