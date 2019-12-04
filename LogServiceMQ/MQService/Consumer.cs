using B_Commerce.Login.Request;
using LogService.DomainClasses;
using MQService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LogService.Services.Abstract;

namespace LogService.MQService
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;

        public Consumer(ILogInfoService _logInfoService,int projectID, string queueName, string Email, bool isRequeired)
        {
            //Put the consumer method outside of constructer
            string logMessage = "";
            _rabbitMQService = new RabbitMQService();

            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {

                    channel.QueueDeclare(queue: queueName,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        //Todo new Method
                        _logInfoService.Add(new LogInfo()
                        {
                            ProjectID = projectID,
                            LogInfoMessage = logMessage,
                            insertDateTime = DateTime.Now
                        }) ;

                        logMessage += message + System.Environment.NewLine;

                    };
                    channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);

                    //Todo new Method
                    if (isRequeired) {

                        MailRequest mailRequest = new MailRequest
                        {
                            ToMail = Email,
                            ToName = Email,
                            Subject = "Log Service Email",
                            Body = logMessage,
                            ProjectCode = "123456"
                        };

                        //TODO Get port and action name from outside
                        HttpClient httpClient = new HttpClient();
                        httpClient.BaseAddress = new Uri("http://localhost:62383/");
                        Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync("/api/Notification/Mail", mailRequest); 
                    }
                }

            }
        }
    }
}
