using System;
using System.Collections.Generic;
using System.Text;
using static B_Commerce.ProductService.Common.Constants;

namespace B_Commerce.ProductService.Response
{
    public class BaseResponse
    {
        public ResponseCode code { get; set; } 
        public string Message
        {
            get;set;
        } 
    }
}
