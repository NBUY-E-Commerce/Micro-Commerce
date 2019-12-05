using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.DomainClasses
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
