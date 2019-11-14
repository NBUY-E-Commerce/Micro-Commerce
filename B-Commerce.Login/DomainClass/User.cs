using B_Commerce.Common.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.DomainClass
{
    public class User : BaseEntity
    {
        public User()
        {
            Tokens = new List<Token>();
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
        public int WrongCount { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LockedTime { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }

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
