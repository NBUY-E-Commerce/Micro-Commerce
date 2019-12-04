using B_Commerce.LogService.Common;
using B_Commerce.LogService.MqServices.Abstract;
using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.Services.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogService.MqServices.Concrete
{
    public class Publisher : IPublisher
    {
        private IRabbitMQConnection _rabbitMQService;
        public Publisher(IRabbitMQConnection rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }
        public BaseResponse Publish(InserLogRequest request)
        {
            MQConstants.MQ_QUEUE_NAME = request.queuName;
            BaseResponse baseResponse = new BaseResponse();
            PublisherRequest publisherRequest = new PublisherRequest { 
                //find project id
            };
            try
            {
                using (var connection = _rabbitMQService.GetRabbitMQConnection())
                {
                    using (var chanel = connection.CreateModel())
                    {
                        chanel.QueueDeclare(queue: request.queuName,
                                     durable: MQConstants.MQ_QUEUE_DURABLE,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                        var properties = chanel.CreateBasicProperties();
                        properties.Persistent = MQConstants.MQ_PROPERTIES_PERSISTENT;

                        var message = JsonConvert.SerializeObject(request);

                        var body = Encoding.UTF8.GetBytes(message);

                        chanel.BasicPublish(exchange: "",
                                     routingKey: request.queuName,
                                     basicProperties: properties,
                                     mandatory: true,
                                     body: body);
                    }
                }
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.SYSTEM_ERROR, ex.Message);
                return baseResponse;
            }

        }
    }
}
