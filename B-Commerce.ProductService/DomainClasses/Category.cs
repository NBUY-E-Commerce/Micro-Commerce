using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class Category : BaseEntity
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
        public bool isActive { get; set; } = true;
        public int? MasterCategoryID { get; set; }
        public string Key { get; set; }
        public virtual Category MasterCategory { get; set; }

        

        public virtual ICollection<Category> SubCategories{get;set;}=new List<Category>();

       public virtual ICollection<Product> Products { get; set; }=new List<Product>();
    }
}
