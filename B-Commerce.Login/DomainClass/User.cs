using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.Common.DomainClasses;

namespace B_Commerce.Login.DomainClass
{
    public class User : BaseEntity
    {
        public User()
        {
            Tokens = new List<Token>();
            AccountVerifications = new List<AccountVerification>();
            SocialInfos = new List<SocialInfo>();
            UserRoles = new List<UserRole>();
            PasswordChanges = new List<PasswordChange>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int WrongCount { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public DateTime? LockedTime { get; set; }

        public virtual ICollection<AccountVerification> AccountVerifications { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
        public virtual ICollection<SocialInfo> SocialInfos { get; set; }
        public virtual ICollection<PasswordChange> PasswordChanges { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public void UserLocked(double banTime)
        {
            this.IsLocked = true;
            this.LockedTime = DateTime.Now.AddHours(banTime);
        }
        public void UserUnLocked()
        {
            this.IsLocked = false;
            this.LockedTime = null;
        }
        public string FullName()
        {
            return $"{ this.Name} {this.Surname}";
        }
    }
}
