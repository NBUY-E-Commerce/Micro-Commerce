using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using B_Commerce.NotificationService.Common;
using B_Commerce.NotificationService.Request.Concrete;
using B_Commerce.NotificationService.Tools.QueueManager.Abstract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace B_Commerce.NotificationService.Tools.QueueManager.Concrete
{
    public class RabbitMQ : IQueueService
    {
        public bool MailPublish(MailRequest pusblishitem)
        {
            MailRequest consume = new MailRequest();
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = Constants.RMQ_HostAdress,
                    Port = Protocols.DefaultProtocol.DefaultPort,
                    UserName = Constants.RMQ_Username,
                    Password = Constants.RMQ_Password,
                    VirtualHost = "/"
                };
                using (IConnection connection = factory.CreateConnection())
                {
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
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool SmsPublish(SmsRequest pusblishitem)
        {
            SmsRequest consume = new SmsRequest();
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = Constants.RMQ_HostAdress,
                    Port = Protocols.DefaultProtocol.DefaultPort,
                    UserName = Constants.RMQ_Username,
                    Password = Constants.RMQ_Password,
                    VirtualHost = "/"
                };
                using (IConnection connection = factory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: Constants.RMQ_QueueNameFor_Sms,
                            durable: Constants.RMQ_QueueDurable,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        string message = JsonConvert.SerializeObject(pusblishitem);
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchange: "",
                            routingKey: Constants.RMQ_QueueNameFor_Sms,
                            basicProperties: null,
                            body: body);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public MailRequest MailConsume()
        {
            MailRequest consume = new MailRequest();
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = Constants.RMQ_HostAdress,
                    Port = Protocols.DefaultProtocol.DefaultPort,
                    UserName = Constants.RMQ_Username,
                    Password = Constants.RMQ_Password,
                    VirtualHost = "/"
                };
                using (IConnection connection = factory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(
                            queue: Constants.RMQ_QueueNameFor_Mail,
                            durable: Constants.RMQ_QueueDurable,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        var consumer = new EventingBasicConsumer(channel);
                        BasicGetResult result = channel.BasicGet(Constants.RMQ_QueueNameFor_Mail, true);
                        if (result != null)
                        {
                            string data = Encoding.UTF8.GetString(result.Body);
                            consume = JsonConvert.DeserializeObject<MailRequest>(data);
                        }
                        return consume;
                    }
                }
            }
            catch (Exception)
            {
                return consume;
            }
        }

        public SmsRequest SmsConsume()
        {
            SmsRequest consume = new SmsRequest();
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = Constants.RMQ_HostAdress,
                    Port = Protocols.DefaultProtocol.DefaultPort,
                    UserName = Constants.RMQ_Username,
                    Password = Constants.RMQ_Password,
                    VirtualHost = "/"
                };
                using (IConnection connection = factory.CreateConnection())
                {
                    using (IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(
                            queue: Constants.RMQ_QueueNameFor_Sms,
                            durable: Constants.RMQ_QueueDurable,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        var consumer = new EventingBasicConsumer(channel);
                        BasicGetResult result = channel.BasicGet(Constants.RMQ_QueueNameFor_Sms, true);
                        if (result != null)
                        {
                            string data = Encoding.UTF8.GetString(result.Body);
                            consume = JsonConvert.DeserializeObject<SmsRequest>(data);
                        }
                        return consume;
                    }
                }
            }
            catch (Exception)
            {
                return consume;
            }
        }

    }
}


