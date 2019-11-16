using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.NotificationService.Request.Abstract;

namespace B_Commerce.NotificationService.Request.Concrete
{
    public class MailRequest : BaseRequest
    {
        public string ToMail { get; set; }
        public string ToName { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
