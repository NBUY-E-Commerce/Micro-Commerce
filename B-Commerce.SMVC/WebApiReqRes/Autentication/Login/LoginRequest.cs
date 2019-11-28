using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

    }
}