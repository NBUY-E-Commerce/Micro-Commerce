using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes
{
    public class CommonResponse
    {
        public int Code { get; set; }

        public string Message { get; set; }


        public void SetHttpError()
        {
            this.Code= -1;
            this.Message = "Http server error";

        }
    }
}