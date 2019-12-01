using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Request
{
    public class ChangePasswordRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassChangeCode { get; set; }
    }
}
