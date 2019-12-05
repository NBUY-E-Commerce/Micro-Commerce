using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Areas.Admin.Models
{
    public class SpecialAreaModel
    {
        public string Name { get; set; }

       [AllowHtml]
        public string Description { get; set; }

        //public List<SpecialAreaModel> SpecialAreas { get; set; } = new List<SpecialAreaModel>();
      
    }
}