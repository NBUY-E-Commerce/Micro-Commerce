using B_Commerce.Login.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Response
{
    public class BaseResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public void SetStatus(Constants.ResponseCode code)
        {
            this.Code = (int)code;
            this.Message = Constants.ResponseCodes[(int)code];
        }
    }
}
