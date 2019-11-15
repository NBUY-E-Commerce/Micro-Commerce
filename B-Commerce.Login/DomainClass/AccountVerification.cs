using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.DomainClass
{
    public class AccountVerification : BaseEntity
    {
        public int UserID { get; set; }
        public string VerificationCode { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
