using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.Common.DomainClasses;

namespace TestProject
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
