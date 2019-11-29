using B_Commerce.ProductService.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
   public class BaseResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public string ExceptionMessage { get; set; }
        public void SetStatus(Constants.ResponseCode code,string exMessage=null)
        {
            Code = (int)code;
            Message = Constants.ResponseCache[code];
            ExceptionMessage = exMessage;
        }
    }
}
