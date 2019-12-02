using MQService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogService.MQService
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;
        public string _queue;

        public Consumer(string queueName)
        {

            _rabbitMQService = new RabbitMQService();

            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (ch, ea) =>
                    {
                        var body = ea.Body;
                        channel.BasicAck(ea.DeliveryTag, false);
                    };
                    String consumerTag = channel.BasicConsume(queueName, false, consumer);
                }
            }
        }
    }
}
