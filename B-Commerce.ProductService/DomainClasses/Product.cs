using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class Product : BaseEntity
    {
        //Properties from Base Entity
        /*  public virtual int ID { get; set; } 
            public bool isDeleted { get; set; } = false;
            public DateTime insertDateTime { get; set; } = DateTime.Now;
            public DateTime? deleteDateTime { get; set; }
            public int? insertUserId { get; set; }
            public int? deleteUserId { get; set; }
         */

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int AvailableCount { get; set; }
        public bool isActive { get; set; } = true;
        public float? PercentageDiscount { get; set; }
        public decimal? SpecialOfferPrice { get; set; }
        public float? SpecialOfferMinimumQuantity { get; set; }
        public float? SpecialOfferMaximumQuantity { get; set; }


        public int CategoryID { get; set; }

      
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public virtual ICollection<ProductSpacialAreaTable> productSpacialAreas { get; set; } = new List<ProductSpacialAreaTable>();
    }
}
