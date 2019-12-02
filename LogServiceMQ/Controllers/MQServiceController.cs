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
        internal string _queue;
        internal JsonResult _queueJson;
        internal Dictionary<int, string> projectsInfo = new Dictionary<int, string>();

        public MQServiceController(
            ILogInfoService logInfoService,
            IProjectInfoService projectInfoService, 
            IProjectOwnerService projectOwnerService) {
            _projectOwnerService = projectOwnerService;
        }

        [HttpPost]
        [Route("InsertLog")]
        public async Task InsertLog(InsertLogRequest request)
        {
            //todo : database e proje tablosu eklenmeli bu tabloda projeno ve code alanı olmalı
            //gelen request eğer dbde bir projeye denk gelmiyorsa hata donulmeli
            InserRequestHelper validationHelper = new InserRequestHelper(_projectInfoService,_projectOwnerService);

            InsertLogReponse responseCheckLogRequestParameters = validationHelper.CheckLogRequestParameters(request);

            if (responseCheckLogRequestParameters.Code!=(int)ResponseCode.SUCCESS) {
                // return;
                throw new Exception(responseCheckLogRequestParameters.Message);
            }
            
            InsertLogReponse responseCheckDbParameters = validationHelper.CheckDbParameters(request);

            if (responseCheckDbParameters.Code != (int)ResponseCode.SUCCESS)
            {
                // return;
                throw new Exception(responseCheckDbParameters.Message);
            }
            try
            {
                Publisher publisher = new Publisher(request.queuName,request.LogInfoMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        [Route("Consume")]
        public void Consume()
        {

            for (; ; )
            {

                Consumer _consumer = new Consumer("LogInfo");
                if (_consumer._queue != null)
                {
                    LogInfo logInfos = new LogInfo
                    {
                        LogInfoMessage = _consumer._queue,

                    };

                    using (LogDbContext db = new LogDbContext())
                    {
                        db.Add(logInfos);

                        db.SaveChanges();
                    }
                }
            }

        }
    }
}