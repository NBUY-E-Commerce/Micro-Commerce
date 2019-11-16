using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.NotificationService.Common;

namespace B_Commerce.NotificationService.Response.Abstract
{
    public abstract class BaseResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public void SetError(Constants.ResponseCode code)
        {
            Code = (int)code;
            Message = Constants.ResponseCodes[(int)code];
        }
    }
}
