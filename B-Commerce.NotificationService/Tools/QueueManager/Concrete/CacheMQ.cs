using B_Commerce.NotificationService.Request.Concrete;
using B_Commerce.NotificationService.Tools.QueueManager.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.NotificationService.Tools.QueueManager.Concrete
{
    public class CacheMQ : IQueueService
    {
        public static List<MailRequest> MailQueue = new List<MailRequest>();
        public static List<SmsRequest> SmsQueue = new List<SmsRequest>();
        public MailRequest MailConsume()
        {
            MailRequest consume = new MailRequest();
            try
            {
                if (MailQueue.Count == 0)
                {
                    return consume;
                }
                else
                {
                    consume = MailQueue[0];
                    MailQueue.RemoveAt(0);
                    return consume;
                }
            }
            catch (Exception)
            {
                return consume;
            }
        }
        public bool MailPublish(MailRequest pusblishitem)
        {
            MailQueue.Add(pusblishitem);
            return true;
        }
        public SmsRequest SmsConsume()
        {
            SmsRequest consume = new SmsRequest();
            try
            {
                if (SmsQueue.Count == 0)
                {
                    return consume;
                }
                else
                {
                    consume = SmsQueue[0];
                    SmsQueue.RemoveAt(0);
                    return consume;
                }
            }
            catch (Exception)
            {
                return consume;
            }
        }
        public bool SmsPublish(SmsRequest pusblishitem)
        {
            SmsQueue.Add(pusblishitem);
            return true;
        }
    }
}
