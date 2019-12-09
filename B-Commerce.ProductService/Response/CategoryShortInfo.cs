using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class CategoryShortInfo
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int? MasterCategoryID { get; set; }
    }
}
