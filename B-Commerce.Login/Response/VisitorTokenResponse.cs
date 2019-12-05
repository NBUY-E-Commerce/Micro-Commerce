using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Response
{
    public class VisitorTokenResponse : BaseResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
