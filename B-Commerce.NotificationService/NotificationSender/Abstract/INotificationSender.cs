using System;
using System.Collections.Generic;
using System.Text;
using B_Commerce.NotificationService.Request.Concrete;

namespace B_Commerce.NotificationService.NotificationSender.Abstract
{
    public interface INotificationSender
    {
        bool SendMail(MailRequest request);
        bool SendSms(SmsRequest request);
    }
}
