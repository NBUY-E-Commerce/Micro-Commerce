using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class SubCategory:BaseEntity
    {   //Properties from Base Entity
    /*  public virtual int ID { get; set; } 
        public bool isDeleted { get; set; } = false;
        public DateTime insertDateTime { get; set; } = DateTime.Now;
        public DateTime? deleteDateTime { get; set; }
        public int? insertUserId { get; set; }
        public int? deleteUserId { get; set; }
     */
        public string CategoryName { get; set; }
        public string Description { get; set; }
        
        public int? SubSubCategoryID { get; set; }
        public bool isActive { get; set; } = true;

        public int MasterCatID { get; set; }
        public  MasterCategory MasterCategory { get; set; }

        public  ICollection<Product> Products { get; set; }
    }
}
