using B_Commerce.LogService.Common;
using B_Commerce.LogService.Helpers.Abstract;
using B_Commerce.LogService.Helpers.Request;
using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.Services.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogService.Helpers.Concrete
{
    public class MailHelper : IMailHelper
    {
        public BaseResponse SendMail(List<InserLogRequest> publisherRequests)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                foreach (InserLogRequest item in publisherRequests)
                {
                    if (item.IsEmailRequired)
                    {
                        MailRequest mailRequest = new MailRequest
                        {
                            ToMail = item.Email,
                            ToName = item.Email,
                            Subject = MailConstants.MAIL_SUBJECT,
                            Body = item.LoginInfoMessage,
                            ProjectCode = MailConstants.MAIL_PROJECT_CODE
                        };

                        HttpClient httpClient = new HttpClient();
                        httpClient.BaseAddress = new Uri(MailConstants.MAIL_URL);
                        Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync(MailConstants.MAIL_ROUTE, mailRequest);

                        if (!httpResponse.Result.IsSuccessStatusCode)
                        {
                            baseResponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                            return baseResponse;
                        }
                    }
                }
            }
            catch (Exception)
            {

                baseResponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return baseResponse;
            }
            baseResponse.SetStatus(ResponseCode.SUCCESS);
            return baseResponse;
        }
       
    }
}

