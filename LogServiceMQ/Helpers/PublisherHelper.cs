using LogService.DTO.Response;
using MQService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LogService.Common.Constants;

namespace LogService.Helpers
{
    public class PublisherHelper
    {
        //TODO Out side of the constructer
        public InsertLogReponse PublishRequest(string queueName, string logInfoMessage)
        {
            InsertLogReponse insertLogReponse = new InsertLogReponse();
            try
            {
                Publisher publisher = new Publisher(queueName, logInfoMessage);
                insertLogReponse.SetStatus(ResponseCode.SUCCESS);
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
