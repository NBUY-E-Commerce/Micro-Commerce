using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class MasterCategory:BaseEntity
    {
        //Properties from Base Entity
        /*  public virtual int ID { get; set; } 
            public bool isDeleted { get; set; } = false;
            public DateTime insertDateTime { get; set; } = DateTime.Now;
            public DateTime? deleteDateTime { get; set; }
            public int? insertUserId { get; set; }
            public int? deleteUserId { get; set; }
         */
        public string CategoryName { get; set; }
        public string Description { get; set; } 
        public bool isActive { get; set; } = true;

        public virtual ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
