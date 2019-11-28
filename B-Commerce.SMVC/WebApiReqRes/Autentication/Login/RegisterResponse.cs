using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class RegisterResponse : CommonResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

        public bool IsValid { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}