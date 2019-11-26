using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.DomainClass
{
    public class SocialInfo
    {
        public int ID { get; set; }
        public string SocialID { get; set; }
        public int UserID { get; set; }
        public int SocialTypeID { get; set; }
        public string AccessToken { get; set; }
        public virtual SocialType SocialType{ get; set; }
        public virtual User User { get; set; }
    }
}
