using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MQService;

namespace LogService.Controllers
{

    public class MQServiceController : Controller
    {
        internal string _queue;

        internal Dictionary<int, string> projectsInfo = new Dictionary<int, string>();

        public ActionResult InsertLog(int ProjectCode, string ProjectPassword, string LogInfo)
        {
            projectsInfo.Add(1, "123");
            try
            {
                foreach (var item in projectsInfo)
                {
                    if (item.Key == ProjectCode && item.Value == ProjectPassword)
                    {
                        _queue = LogInfo;
                        Publisher publisher = new Publisher("LogInfo", _queue);

                        break;
                    }

                    projectsInfo.Clear();

                    throw new Exception("Proje kodu veya şifresi yanlış");
                }

                
                return null;
                 

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
