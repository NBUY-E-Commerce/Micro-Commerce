using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Response
{
    public class PasswordChangeResponse : BaseResponse
    {
        public string Email { get; set; }
        public string PassChangeCode { get; set; }
    }
}
