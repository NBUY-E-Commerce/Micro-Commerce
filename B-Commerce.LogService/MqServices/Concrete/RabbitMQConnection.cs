using B_Commerce.LogService.Common;
using B_Commerce.LogService.MqServices.Abstract;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.MqServices.Concrete
{
    public class RabbitMQConnection: IRabbitMQConnection
    {
        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                HostName = MQConstants.MQ_HOSTNAME_NAME
            };
            //connectionFactory.AutomaticRecoveryEnabled = MQConstants.MQ_AUTOMATIC_RECOVERY_ENABLED;
            return connectionFactory.CreateConnection();
        }
    }
}
