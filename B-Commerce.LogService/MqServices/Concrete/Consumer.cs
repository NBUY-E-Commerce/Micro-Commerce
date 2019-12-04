using B_Commerce.LogService.Common;
using B_Commerce.LogService.MqServices.Abstract;
using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.MqServices.Response;
using B_Commerce.LogService.Services.Response;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogService.MqServices.Concrete
{
    public class Consumer : IConsumer
    {
        private IRabbitMQConnection _rabbitMQService;
        public Consumer(IRabbitMQConnection rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public ConsumerResponse Consume()
        {
            ConsumerResponse consumerResponse = new ConsumerResponse();
            try
            {
                using (IConnection connection = _rabbitMQService.GetRabbitMQConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {

                        channel.QueueDeclare(queue: MQConstants.MQ_QUEUE_NAME,
                                                 durable: MQConstants.MQ_QUEUE_DURABLE,
                                                 exclusive: false,
                                                 autoDelete: false,
                                                 arguments: null);

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body); 
                            InserLogRequest consumerResult = JsonConvert.DeserializeObject<InserLogRequest>(message);
                            consumerResponse.publisherRequests.Add(consumerResult);
                        };
                        channel.BasicConsume(queue: MQConstants.MQ_QUEUE_NAME,
                                             autoAck: true,
                                             consumer: consumer);
                    }
                }
                consumerResponse.SetStatus(ResponseCode.SUCCESS);
                return consumerResponse;

            }
            catch (Exception ex)
            {
                consumerResponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return consumerResponse;

            }
        }
    }
}
