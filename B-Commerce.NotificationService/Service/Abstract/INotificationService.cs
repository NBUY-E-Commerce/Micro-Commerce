using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.NotificationService.Request.Concrete;
using B_Commerce.NotificationService.Response.Concrete;

namespace B_Commerce.NotificationService.Service.Abstract
{
    public interface INotificationService
    {
        NotificationResponse SendMail(MailRequest request);
        NotificationResponse SendSms(SmsRequest request);
    }
}
