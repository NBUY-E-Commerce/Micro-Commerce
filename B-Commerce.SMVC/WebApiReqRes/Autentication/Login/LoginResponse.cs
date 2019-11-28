using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class LoginResponse : CommonResponse
    {
        public string token { get; set; }
        public string username { get; set; }
    }
}