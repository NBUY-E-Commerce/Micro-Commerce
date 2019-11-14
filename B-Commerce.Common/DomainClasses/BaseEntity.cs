using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Common.DomainClasses
{
    public abstract class BaseEntity
    {
        public virtual int ID { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime insertDateTime { get; set; } = DateTime.Now;
        public DateTime? deleteDateTime { get; set; } 
        public int? insertUserId { get; set; }
        public int? deleteUserId { get; set; }
    }
}
