using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class SpacialArea:BaseEntity
    {
        /*  public virtual int ID { get; set; } 
             public bool isDeleted { get; set; } = false;
             public DateTime insertDateTime { get; set; } = DateTime.Now;
             public DateTime? deleteDateTime { get; set; }
             public int? insertUserId { get; set; }
             public int? deleteUserId { get; set; }
        */
        public string Name { get; set; }

  
        public string Description { get; set; }
        public virtual ICollection<ProductSpacialAreaTable> productSpacialAreas { get; set; } = new List<ProductSpacialAreaTable>();
    }
}
