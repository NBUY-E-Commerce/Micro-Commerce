using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.DomainClass
{
    public class PasswordChange : BaseEntity
    {
        public int UserID { get; set; }
        public string ChangeCode { get; set; }
        public string Email { get; set; }
        public DateTime ExpireDate { get; set; } = DateTime.Now.AddHours(1);

        public virtual User User { get; set; }

        public bool IsExpired()
        {
            if (this.ExpireDate<DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
