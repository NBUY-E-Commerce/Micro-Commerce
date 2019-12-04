using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.Helpers.Request
{
    public class AuthenticationRequest
    {
        public string ProjectCode { get; set; }
        public string Password { get; set; }
    }
}
