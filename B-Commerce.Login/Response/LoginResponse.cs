using B_Commerce.Login.DomainClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Response
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public bool IsVerify { get; set; }

        public List<string> UserRole { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
