using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.Services.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.MqServices.Response
{
    public class ConsumerResponse:BaseResponse
    {
       public List<InserLogRequest> publisherRequests;
        public ConsumerResponse() {
            publisherRequests = new List<InserLogRequest>();
        }
    }
}
