using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Request
{
    public class PasswordChangeRequest
    {
        public string Email { get; set; }
        public string PassChangeCode { get; set; }
    }
}
