using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel()
        {
            loginModel = new LoginModel();
            registerModel = new RegisterModel();
        }
        public LoginModel loginModel { get; set; }

        public RegisterModel registerModel { get; set; }
    }
}