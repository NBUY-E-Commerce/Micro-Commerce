using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.MqServices.Request
{
    public class InserLogRequest
    {
        public string ProjectCode { get; set; }
        public string Password { get; set; }
        public string queuName { get; set; }
        public string LoginInfoMessage { get; set; }
        public string Email { get; set; }
        public bool IsEmailRequired { get; set; }
    }
}
