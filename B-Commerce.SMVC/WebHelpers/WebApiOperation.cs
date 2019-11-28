using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace B_Commerce.SMVC.WebHelpers
{
    public class WebApiOperation
    {
        public static TResponse SendPost<TRequest, TResponse>(string baseurl, string endpoint, TRequest request) where TResponse : CommonResponse, new()
        {
            TResponse response = new TResponse();

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseurl);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
           // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync(endpoint, request);

            //200 donudumu
            if (httpResponse.Result.IsSuccessStatusCode)
            {
                return httpResponse.Result.Content.ReadAsAsync<TResponse>().Result;
            }

            try
            {
                response = httpResponse.Result.Content.ReadAsAsync<TResponse>().Result;
            }
            catch (Exception ex)
            {

                ((CommonResponse)response).SetHttpError();

            }

            return response;
        }
    }
}