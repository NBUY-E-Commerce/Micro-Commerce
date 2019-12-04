using B_Commerce.LogService.Helpers.Request;
using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.Helpers.Abstract
{
    public interface IDBHelper
    {
        BaseResponse Add(List<InserLogRequest> publishers);
        BaseResponse Authentication(AuthenticationRequest request);
    }
}
