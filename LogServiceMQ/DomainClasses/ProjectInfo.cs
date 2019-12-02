using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.DomainClasses
{
    public class ProjectInfo:BaseEntity
    {
        /*
        public virtual int ID { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime insertDateTime { get; set; } = DateTime.Now;
        public DateTime? deleteDateTime { get; set; } 
        public int? insertUserId { get; set; }
        public int? deleteUserId { get; set; }
         */
        public string ProjectCode { get; set; }
        public string Password { get; set; }
        public string qeueName { get;set;}
        public virtual ICollection<LogInfo> LogInfos { get; set; } 

        
        public virtual ICollection<ProjectOwner> ProjectOwners { get; set; } 
        
    }
}
