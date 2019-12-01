using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.NotificationService.Api.DTO
{
    public class Register
    {
        public string ProjectName { get; set; }
        public string OwnerMail { get; set; }
        public string OwnerPhone { get; set; }
    }
}
