using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQService
{

    internal class Publisher
    {
        private readonly RabbitMQService _rabbitMQService;
        public Publisher(string queueName, string message)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var chanel = connection.CreateModel())
                {
                    
                    chanel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    var properties = chanel.CreateBasicProperties();
                    properties.Persistent = true;
                    var body = Encoding.UTF8.GetBytes(message);
                    chanel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: properties,
                                 body: body);
                }
            }
        }
    }
}
