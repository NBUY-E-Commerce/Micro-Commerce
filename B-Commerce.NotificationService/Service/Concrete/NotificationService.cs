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
        private Timer _timer;

        public NotificationService(IQueueService queueService, IAuthControlService authControl, INotificationSender notificationSender)
        {
            _queueService = queueService;
            _authControl = authControl;
            _notificationSender = notificationSender;
            _timer = new Timer() { Interval = Constants.RMQ_ConsumerRefreshTime};
            _timer.Start();
        }

        public NotificationResponse SendMail(MailRequest request)
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

            if (_authControl.MailAuthControl(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.MAİL_AUTHORİZATİON_ERROR);
                return response;
            }
            if (_authControl.MailLimitControl(request.ProjectCode))
            {
                response.SetError(Constants.ResponseCode.MAİL_LİMİT_ERROR);
                return response;
            }

            if (_queueService.Publish(request))
            {
                response.SetError(Constants.ResponseCode.SUCCESS);
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

            if (_queueService.Publish(request))
            {
                response.SetError(Constants.ResponseCode.SUCCESS);
                return response;
            }
            response.SetError(Constants.ResponseCode.SYSTEM_ERROR);
            return response;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
          object consume = _queueService.Consume();
          if (consume == null) return;
          if (consume is MailRequest)
          {
              _notificationSender.SendMail(consume as MailRequest);
              return;
          }
          if (consume is SmsRequest)
          {
              _notificationSender.SendSms(consume as SmsRequest);
              return;
          }
        }
    }
}
