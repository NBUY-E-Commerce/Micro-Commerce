using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class CategoryDetailModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; } = true;
        public int? MasterCategoryID { get; set; }
    }
}