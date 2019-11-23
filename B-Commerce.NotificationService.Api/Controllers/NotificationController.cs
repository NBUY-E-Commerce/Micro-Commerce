using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.NotificationService.Common;
using B_Commerce.NotificationService.DomainClass;
using B_Commerce.NotificationService.Request.Concrete;
using B_Commerce.NotificationService.Response.Concrete;
using B_Commerce.NotificationService.Service.Abstract;
using B_Commerce.NotificationService.Tools.ProjectAuthManager.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B_Commerce.NotificationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        INotificationService _notificationService;
        IAuthControlService _authControlService;
        public NotificationController(INotificationService notificationService, IAuthControlService authService)
        {
            _notificationService = notificationService;
            _authControlService = authService;
        }

        [HttpPost]
        [Route("Mail")]
        public ActionResult Mail(MailRequest request)
        {
            NotificationResponse response = new NotificationResponse();
            try
            {
                response = _notificationService.SendMail(request);
                if (response.Code == (int)Constants.ResponseCode.SUCCESS)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(402, response);
                }
            }
            catch (Exception e)
            {
                return StatusCode(402, response);
            }
        }

        [HttpPost]
        [Route("Sms")]
        public ActionResult Sms(SmsRequest request)
        {
            NotificationResponse response = new NotificationResponse();
            try
            {
                response = _notificationService.SendSms(request);
                if (response.Code == (int)Constants.ResponseCode.SUCCESS)
                {
                    return Ok(response);
                }
                else
                {
                    return StatusCode(402, response);
                }
            }
            catch (Exception)
            {
                return StatusCode(402, response);
            }
        }

        [HttpPost]
        [Route("RegisterProject")]
        public ActionResult RegisterProject(ProjectPermission permission)
        {
            try
            {
                _authControlService.RegisterProject(permission);
                return StatusCode(StatusCodes.Status201Created, permission);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, permission);
            }
        }
    }
}