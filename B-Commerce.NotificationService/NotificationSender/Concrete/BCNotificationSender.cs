using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using B_Commerce.NotificationService.Common;
using B_Commerce.NotificationService.Request.Concrete;
using B_Commerce.NotificationService.Response.Concrete;
using B_Commerce.NotificationService.NotificationSender.Abstract;

namespace B_Commerce.NotificationService.NotificationSender.Concrete
{
    public class BCNotificationSender : INotificationSender
    {
        public bool SendMail(MailRequest request)
        {
            try
            {
                var fromAddress = new MailAddress(Constants.FromMail, Constants.FromName);
                var toAddress = new MailAddress(request.ToMail, request.ToName);

                var smtp = new SmtpClient
                {
                    Host = Constants.MailServer,
                    Port = Constants.port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Constants.FromMail, Constants.fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = request.Subject,
                    Body = request.Body
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SendSms(SmsRequest request)
        {
            try
            {
                string number = request.PhoneNumber + Constants.serverattr_sms;
                var fromAddress = new MailAddress(Constants.FromMail_sms, Constants.FromName_sms);
                var toAddress = new MailAddress(number);

                var smtp = new SmtpClient
                {
                    Host = Constants.MailServer,
                    Port = Constants.port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Constants.FromMail, Constants.fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = request.Subject,
                    Body = request.Text
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
