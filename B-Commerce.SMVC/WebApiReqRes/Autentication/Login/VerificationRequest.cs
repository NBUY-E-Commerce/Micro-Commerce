using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class VerificationRequest
    {
        public string Email { get; set; }

        public string Code { get; set; }
    }
}