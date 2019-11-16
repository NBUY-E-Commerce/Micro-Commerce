using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.DomainClass
{
    public class SocialType
    {
        public int ID { get; set; }
        public string SocialName { get; set; }
        public virtual ICollection<SocialInfo> SocialInfos { get; set; }
    }
}
