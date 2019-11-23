using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using B_Commerce.NotificationService.Common;
using B_Commerce.NotificationService.NotificationSender.Abstract;
using B_Commerce.NotificationService.Request.Concrete;
using B_Commerce.NotificationService.Response.Concrete;
using B_Commerce.NotificationService.Service.Abstract;
using B_Commerce.NotificationService.Tools.ProjectAuthManager.Abstract;
using B_Commerce.NotificationService.Tools.QueueManager.Abstract;

namespace B_Commerce.NotificationService.Service.Concrete
{
    public class NotificationService : INotificationService
    {
        private IAuthControlService _authControl;
        private IQueueService _queueService;
        private INotificationSender _notificationSender;
        static System.Timers.Timer _consumeTimer;

        public NotificationService(IQueueService queueService, IAuthControlService authControl, INotificationSender notificationSender)
        {
            _queueService = queueService;
            _authControl = authControl;
            _notificationSender = notificationSender;

            _consumeTimer = new System.Timers.Timer(Constants.RMQ_ConsumerRefreshTime);
            _consumeTimer.Elapsed += new ElapsedEventHandler(_timer_Tick_Mail);
            _consumeTimer.Elapsed += new ElapsedEventHandler(_timer_Tick_Sms);
            _consumeTimer.Enabled = true;
            _consumeTimer.Start();
        }

        public NotificationResponse SendMail(MailRequest request)
        {
            NotificationResponse response = new NotificationResponse();
            if (!_authControl.ProjectCodeCheck(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.INVALİD_PROJECT_CODE);
                return response;
            }

            if (_authControl.ProjectBannCheck(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.PROJECT_BANNED);
                return response;
            }

            if (!_authControl.MailAuthControl(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.MAİL_AUTHORİZATİON_ERROR);
                return response;
            }

            if (!_authControl.MailLimitControl(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.MAİL_LİMİT_ERROR);
                return response;
            }

            if (_queueService.MailPublish(request))
            {
                response.SetError(Constants.ResponseCode.SUCCESS);
                _authControl.PlusMailCount(request.ProjectCode);
                return response;
            }
            response.SetError(Constants.ResponseCode.SYSTEM_ERROR);
            return response;

        }
        public NotificationResponse SendSms(SmsRequest request)
        {
            NotificationResponse response = new NotificationResponse();
            if (_authControl.ProjectCodeCheck(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.INVALİD_PROJECT_CODE);
                return response;
            }

            if (_authControl.ProjectBannCheck(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.PROJECT_BANNED);
                return response;
            }

            if (_authControl.SmsAuthControl(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.MAİL_AUTHORİZATİON_ERROR);
                return response;
            }
            if (_authControl.SmsLimitControl(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.MAİL_LİMİT_ERROR);
                return response;
            }

            if (_queueService.SmsPublish(request))
            {
                response.SetError(Constants.ResponseCode.SUCCESS);
                _authControl.PlusSmsCount(request.ProjectCode);
                return response;
            }
            response.SetError(Constants.ResponseCode.SYSTEM_ERROR);
            return response;
        }

        private void _timer_Tick_Mail(object sender, EventArgs e)
        {
            MailRequest consume = _queueService.MailConsume();
            if (consume.ToMail == null) return;
            _notificationSender.SendMail(consume);
        }

        private void _timer_Tick_Sms(object sender, EventArgs e)
        {
            SmsRequest consume = _queueService.SmsConsume();
            if (consume.PhoneNumber == null) return;
            _notificationSender.SendSms(consume);
        }
    }
}
