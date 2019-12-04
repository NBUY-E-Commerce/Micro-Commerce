using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.MqServices.Abstract
{
    public interface IRabbitMQConnection
    {
        IConnection GetRabbitMQConnection();
    }
}
