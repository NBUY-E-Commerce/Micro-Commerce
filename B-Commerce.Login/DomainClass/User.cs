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
//face login için prop
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public int WrongCount { get; set; }
        public DateTime? BannedUntil { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }
    }
}
