using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using B_Commerce.LogService.Common;
using B_Commerce.LogService.Helpers.Abstract;
using B_Commerce.LogService.Helpers.Concrete;
using B_Commerce.LogService.Helpers.Request;
using B_Commerce.LogService.MqServices.Abstract;
using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.MqServices.Response;
using B_Commerce.LogService.Services.Response;
using Microsoft.AspNetCore.Mvc;
using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogServiceController : Controller
    {
        private IPublisher _publisher;
        private IConsumer _consumer;
        private IDBHelper _dbHelper;
        private IMailHelper _mailHelper;
        public static System.Timers.Timer aTimer;
        public LogServiceController(IPublisher publisher,
            IConsumer consumer,
            IDBHelper dbHelper,
            IMailHelper mailHelper)
        {
            _publisher = publisher;
            _consumer = consumer;
            _dbHelper = dbHelper;
            _mailHelper = mailHelper;

            aTimer = new System.Timers.Timer(MQConstants.MQ_CONSUMER_TIMER_ELAPSE);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Publish")]
        public ActionResult Publish(InserLogRequest request)
        {
            BaseResponse baseResponse=null;
            //autontication
            var autRequest = new AuthenticationRequest
            {
                ProjectCode = request.ProjectCode,
                Password=request.Password
            };
            baseResponse = _dbHelper.Authentication(autRequest);
            if (baseResponse.Code!=(int)ResponseCode.SUCCESS) {
                return BadRequest(baseResponse.Message);
            }


            baseResponse = _publisher.Publish(request);
            if (baseResponse.Code != (int)ResponseCode.SUCCESS)
            {
                return BadRequest(baseResponse);
            }
            return Ok(baseResponse);
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Consumer Calışacak
            ConsumerResponse response = _consumer.Consume();
            if (response.Code != (int)ResponseCode.SUCCESS
                || response.publisherRequests.Count < 1) return;

            _dbHelper.Add(response.publisherRequests);
            _mailHelper.SendMail(response.publisherRequests);   


        }
    }
}