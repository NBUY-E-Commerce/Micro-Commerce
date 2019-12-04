using LogService.DTO.Response;
using LogService.MQService;
using LogService.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LogService.Common.Constants;

namespace LogService.Helpers
{
    public class ConsumerHelper
    {
        private IProjectInfoService _projectInfoService;
   
        private ILogInfoService _logInfoService;
        public ConsumerHelper(
            ILogInfoService logInfoService,
            IProjectInfoService projectInfoService)
        {
            _logInfoService = logInfoService;
            _projectInfoService = projectInfoService;
        }
        //TODO Combine Consumer and ConsumerHelper
        public InsertLogReponse ConsumerReques(string projectCode,string queueName,string Email,bool isRequeired) {
            InsertLogReponse insertLogReponse = new InsertLogReponse();
            try
            {
                var result = _projectInfoService.Get(t=>t.ProjectCode==projectCode).FirstOrDefault();
                if (result!=null) {
                    Consumer consumer = new Consumer(_logInfoService, result.ID, queueName, Email, isRequeired);

                    insertLogReponse.SetStatus(ResponseCode.SUCCESS);
                    return insertLogReponse;
                }
                insertLogReponse.SetStatus(ResponseCode.INVALID_PROJECT_CODE);
                return insertLogReponse;
            }
            catch (Exception ex)
            {
                insertLogReponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                insertLogReponse.Message = ex.Message;
                return insertLogReponse;
            }
        }
    }
}
