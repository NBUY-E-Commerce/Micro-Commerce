using B_Commerce.NotificationService.Request.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.NotificationService.Tools.QueueManager.Abstract
{
    public interface IQueueService
    {
        bool MailPublish(MailRequest pusblishitem);
        bool SmsPublish(SmsRequest pusblishitem);
        MailRequest MailConsume();
        SmsRequest SmsConsume();
    }
}
