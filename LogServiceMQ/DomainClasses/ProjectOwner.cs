using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.DomainClasses
{
    public class ProjectOwner:BaseEntity
    {
        /*
        public virtual int ID { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime insertDateTime { get; set; } = DateTime.Now;
        public DateTime? deleteDateTime { get; set; } 
        public int? insertUserId { get; set; }
        public int? deleteUserId { get; set; }
         */

        public string Email { get; set; }
        public bool IsRequestEmail { get; set; } = false;
        public int ProjectID { get; set; }
        public virtual ProjectInfo ProjectInfo { get; set; }
    }
}
