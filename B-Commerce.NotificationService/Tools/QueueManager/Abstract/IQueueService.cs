using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.NotificationService.Tools.QueueManager.Abstract
{
    public interface IQueueService
    {
        bool Publish(object pusblishitem);
        object Consume();
    }
}
