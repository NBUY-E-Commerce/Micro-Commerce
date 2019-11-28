using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace B_Commerce.LoginApi.Middlewares
{
    public class LogMiddleware
    {

        private readonly RequestDelegate _next;
        public LogMiddleware(RequestDelegate next)
        {

            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:60017");

                //Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync("/api/MQService/InsertLog", mailRequest);

                //if (!httpResponse.Result.IsSuccessStatusCode)
                //{
                //    response.SetStatus(Constants.ResponseCode.FAILED);
                //    return response;
                //}


            }







        }

    }
}
