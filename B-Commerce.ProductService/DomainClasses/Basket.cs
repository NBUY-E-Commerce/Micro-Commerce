using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class Basket:BaseEntity
    {
        //Properties from Base Entity
        /*  public virtual int ID { get; set; } 
            public bool isDeleted { get; set; } = false;
            public DateTime insertDateTime { get; set; } = DateTime.Now;
            public DateTime? deleteDateTime { get; set; }
            public int? insertUserId { get; set; }
            public int? deleteUserId { get; set; }
         */
         //My basket ıphone-->>10
                     //samsung=>>5   

        public string Name { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
