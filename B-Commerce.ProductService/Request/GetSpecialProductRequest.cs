using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Request
{
   public  class GetSpecialProductRequest
    {

        public int SpacialID { get; set; }

        public int PageNumber { get; set; }

        public int Count { get; set; }
    }
}
