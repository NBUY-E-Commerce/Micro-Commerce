using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.NotificationService.Request.Abstract;

namespace B_Commerce.NotificationService.Request.Concrete
{
    public class SmsRequest : BaseRequest
    {
        public string PhoneNumber { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
    }
}
