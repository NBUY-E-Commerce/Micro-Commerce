using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.MqServices.Abstract
{
    public interface IPublisher
    {
        BaseResponse Publish(InserLogRequest request);
    }
}
