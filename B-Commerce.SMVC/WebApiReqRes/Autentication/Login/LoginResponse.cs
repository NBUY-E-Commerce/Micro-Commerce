using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class LoginResponse : CommonResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public bool IsVerify { get; set; }
        public DateTime ExpireDate { get; set; }

        public List<string> UserRole { get; set; }
    }
}