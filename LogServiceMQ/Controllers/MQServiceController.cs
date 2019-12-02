using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogService.DomainClasses;
using LogService.DTO;
using LogService.DTO.Request;
using LogService.DTO.Response;
using LogService.Helpers;
using LogService.MQService;
using LogService.MyDbContext;
using LogService.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQService;
using static LogService.Common.Constants;

namespace LogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQServiceController : ControllerBase
    {
        private IProjectInfoService _projectInfoService;
        private IProjectOwnerService _projectOwnerService;
        private ILogInfoService _logInfoService;
        public MQServiceController(
            IProjectInfoService projectInfoService,
            IProjectOwnerService projectOwnerService,
            ILogInfoService logInfoService)
        {
            _projectOwnerService = projectOwnerService;
            _projectInfoService = projectInfoService;
            _logInfoService = logInfoService;
        }

        [HttpPost]
        [Route("api/[controller]/InsertLog")]
        public async Task InsertLog(InsertLogRequest request)
        {
            //todo : database e proje tablosu eklenmeli bu tabloda projeno ve code alanı olmalı
            //gelen request eğer dbde bir projeye denk gelmiyorsa hata donulmeli
            StatusControlHelper validationHelper = new StatusControlHelper(_projectInfoService, _projectOwnerService);



            InsertLogReponse responseCheckLogRequestParameters = validationHelper.CheckRequestParameters(request);
            if (responseCheckLogRequestParameters.Code != (int)ResponseCode.SUCCESS)
            {
                // return;
                throw new Exception(responseCheckLogRequestParameters.Message);
            }


            InsertLogReponse responseCheckDbParameters = validationHelper.CheckDbParameters(request);
            if (responseCheckDbParameters.Code != (int)ResponseCode.SUCCESS)
            {
                // return;
                throw new Exception(responseCheckDbParameters.Message);
            }


            PublisherHelper publisherHelper = new PublisherHelper();

            InsertLogReponse responsePublish = publisherHelper.PublishRequest(request.queuName, request.LogInfoMessage);
            if (responsePublish.Code != (int)ResponseCode.SUCCESS)
            {
                throw new Exception(responsePublish.Message);
            }

            await Task.CompletedTask;
        }
        [HttpGet]
        [Route("api/[controller]/ConsumeLog")]
        public async Task ConsumeLog(InsertLogRequest request)
        {
            StatusControlHelper validationHelper = new StatusControlHelper(_projectInfoService, _projectOwnerService);
            ConsumerHelper consumerHelper = new ConsumerHelper(_logInfoService, _projectInfoService);

            InsertLogReponse responseCheckLogRequestParameters = validationHelper.CheckRequestParameters(request);
            if (responseCheckLogRequestParameters.Code != (int)ResponseCode.SUCCESS)
            {
                // return;
                throw new Exception(responseCheckLogRequestParameters.Message);
            }

            //GetMEssage and sent
            InsertLogReponse consumerCheckResponse = consumerHelper.ConsumerReques(request.ProjectCode, request.queuName, request.Email, request.IsRequestEmail);

            if (consumerCheckResponse.Code != (int)ResponseCode.SUCCESS)
            {
                throw new Exception(consumerCheckResponse.Message);
            }
            //for (; ; )
            //{

            //    Consumer _consumer = new Consumer("LogInfo");
            //    if (_consumer._queue != null)
            //    {
            //        LogInfo logInfos = new LogInfo
            //        {
            //            LogInfoMessage = _consumer._queue,

            //        };

            //        using (LogDbContext db = new LogDbContext())
            //        {
            //            db.Add(logInfos);

            //            db.SaveChanges();
            //        }
            //    }
            //}
            await Task.CompletedTask;

        }
    }
}