using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.Helpers.Abstract
{
    public interface IMailHelper
    {
        BaseResponse SendMail(List<InserLogRequest> publisherRequests);
  
    }
}
