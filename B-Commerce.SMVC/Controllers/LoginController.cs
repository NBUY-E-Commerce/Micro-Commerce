using B_Commerce.SMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }

        public PartialViewResult TopBar()
        {

            return PartialView("_PartialTopBar");

        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {

            if (!ModelState.IsValid)
            {
                return View("");
            }
            //using System.Net.Http;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:56412/");
            //System.Net.Http.Formating eklenirse PostAsJsonAsync methodu gelir
            // Task<HttpResponseMessage> httpResponseMessage = httpClient.PostAsync("/api/Login/Login");

            Task<HttpResponseMessage> httpResponse = httpClient.PostAsJsonAsync("/api/Login/Login", loginModel);

            //200 donudumu
            if (httpResponse.Result.IsSuccessStatusCode)
            {
               // httpResponse.Result.Content.ReadAsAsync<>

            }

            //login service i çağırmalıyım
            return null;
        }

    }
}