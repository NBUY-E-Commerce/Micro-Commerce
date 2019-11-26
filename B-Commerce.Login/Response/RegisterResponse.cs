using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Response
{
    public class RegisterResponse : BaseResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
