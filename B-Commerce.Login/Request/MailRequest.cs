using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Request
{
    public class MailRequest
    {
        public string ToMail { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ProjectCode { get; set; }
    }
}
