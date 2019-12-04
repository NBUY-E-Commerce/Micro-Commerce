using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public List<string> ProductImages { get; set; } = new List<string>();


    }
    public class PagingInfo
    {
        public int CurrentPage { get; set; }

        public int Demand { get; set; }

        public int LastPage { get; set; }


    }


}