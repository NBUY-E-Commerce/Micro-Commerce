using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Product
{

    public class GetSpecialProductRequest
    {

        public int SpacialID { get; set; }

        public int PageNumber { get; set; }

        public int Count { get; set; }
    }

}