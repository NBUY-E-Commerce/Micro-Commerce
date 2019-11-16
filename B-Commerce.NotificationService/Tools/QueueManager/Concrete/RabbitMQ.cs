using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using B_Commerce.NotificationService.Common;
using B_Commerce.NotificationService.Tools.QueueManager.Abstract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace B_Commerce.NotificationService.Tools.QueueManager.Concrete
{
    public class RabbitMQ : IQueueService
    {
        //todo : sonraya kaldı
        public bool Publish(object pusblishitem)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = Constants.RMQ_HostAdress };
                using (IConnection connection = factory.CreateConnection())
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: Constants.RMQ_QueueNameFor_Mail,
                        durable: Constants.RMQ_QueueDurable,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message = JsonConvert.SerializeObject(pusblishitem);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: Constants.RMQ_QueueNameFor_Mail,
                        basicProperties: null,
                        body: body);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
        public object Consume()
        {
            object consume = null;
            try
            {
                var factory = new ConnectionFactory() { HostName = Constants.RMQ_HostAdress };
                using (IConnection connection = factory.CreateConnection())
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: Constants.RMQ_QueueNameFor_Mail,
                        durable: Constants.RMQ_QueueDurable,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        consume = JsonConvert.DeserializeObject<object>(message);
                    };
                    channel.BasicConsume(queue: Constants.RMQ_QueueNameFor_Mail,
                        autoAck: true,
                        consumer: consumer);
                }

                return consume;
            }
            catch (Exception)
            {
                return consume;
            }
        }
    }
}


