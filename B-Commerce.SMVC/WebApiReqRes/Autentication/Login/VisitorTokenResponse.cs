using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class VisitorTokenResponse:CommonResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}