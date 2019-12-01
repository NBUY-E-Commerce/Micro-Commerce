using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class PasswordChangeResponse:CommonResponse
    {
        public string Email { get; set; }
        public string PassChangeCode { get; set; }
        public string Password { get; set; }

    }
}