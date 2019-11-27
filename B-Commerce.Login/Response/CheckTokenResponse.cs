using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Response
{
    public class CheckTokenResponse:BaseResponse
    {
        public string Username { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
