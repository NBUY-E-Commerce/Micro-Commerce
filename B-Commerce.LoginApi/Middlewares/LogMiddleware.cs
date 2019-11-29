using B_Commerce.Common.Helper;
using B_Commerce.Login.Request;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static B_Commerce.Common.Helper.ExceptionHelper;

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

                LogException exception = ExceptionHelper.LogException.ShowDebugInfo(ex);

                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://localhost:62388");

                Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync("/api/MQService/InsertLog", new LogRequest
                {
                    ProjectCode = 1,
                    ProjectPassword = "123456",
                    LogInfo = exception.ToString()

                });

                if (!httpResponse.Result.IsSuccessStatusCode)
                {
                  
                }

                httpContext.Response.StatusCode = 500;

            }







        }

    }
}
