using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.DomainClasses
{
    public class LogInfo:BaseEntity
    {
        /*
        public virtual int ID { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime insertDateTime { get; set; } = DateTime.Now;
        public DateTime? deleteDateTime { get; set; } 
        public int? insertUserId { get; set; }
        public int? deleteUserId { get; set; }
         */
     
        public string LogInfoMessage { get; set; }
        public int ProjectID { get; set; }
        public virtual ProjectInfo ProjectInfo { get; set; }
    }
}
