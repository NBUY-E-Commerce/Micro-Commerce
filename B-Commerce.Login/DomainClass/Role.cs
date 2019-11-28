using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.DomainClass
{
    public class Role
    {
        public Role()
        {
            UserRoles = new List<UserRole>();
        }
        public int RoleID { get; set; }
        public virtual string RoleName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
