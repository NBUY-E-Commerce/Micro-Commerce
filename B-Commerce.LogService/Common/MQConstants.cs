using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.Common
{
    public class MQConstants
    {   public static bool MQ_AUTOMATIC_RECOVERY_ENABLED = true;
        public static string MQ_HOSTNAME_NAME = "localhost";
        public static string MQ_QUEUE_NAME = "";
        public static bool MQ_QUEUE_DURABLE = true;
        public static bool MQ_PROPERTIES_PERSISTENT=true;

        public static int MQ_CONSUMER_TIMER_ELAPSE = 1000;
    }
}
