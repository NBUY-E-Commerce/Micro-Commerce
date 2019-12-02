using LogService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.DTO.Response
{
    public class InsertLogReponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public string ExceptionMessage { get; set; }
        public void SetStatus(Constants.ResponseCode code, string exMessage = null)
        {
            Code = (int)code;
            Message = Constants.ResponseCache[code];
            ExceptionMessage = exMessage;
        }
    }
}
