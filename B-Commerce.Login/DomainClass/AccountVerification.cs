using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.DomainClass
{
    public class AccountVerification:BaseEntity
    {
        public string VerificationCode { get; set; }
        public int UserID { get; set; }
        public DateTime ExpireTime { get; set; }
        public virtual User User { get; set; }
    }
}
