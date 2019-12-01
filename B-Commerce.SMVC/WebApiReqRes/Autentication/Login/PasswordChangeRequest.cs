using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class PasswordChangeRequest
    {
        public string Email { get; set; }
        public string PassChangeCode { get; set; }
    }
}