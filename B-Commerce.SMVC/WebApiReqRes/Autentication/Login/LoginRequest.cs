using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class LoginRequest
    {
        public string email { get; set; }

        public string password { get; set; }

        public string phone { get; set; }

    }
}