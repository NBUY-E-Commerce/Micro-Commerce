using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogService.DomainClasses;
using LogService.MQService;
using LogService.MyDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQService;

namespace LogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQServiceController : ControllerBase
    {
        internal string _queue;

        internal JsonResult _queueJson;

        internal Dictionary<int, string> projectsInfo = new Dictionary<int, string>();

        public void InsertLog(int ProjectCode, string ProjectPassword, string LogInfo)
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
            }
            catch (Exception)
            {
               throw;
            }
        }

        public void InsertLog(int ProjectCode, string ProjectPassword, JsonResult LogInfo)
        {
            projectsInfo.Add(1, "123");
            try
            {
                foreach (var item in projectsInfo)
                {
                    if (item.Key == ProjectCode && item.Value == ProjectPassword)
                    {
                        _queueJson = LogInfo;
                        Publisher publisher = new Publisher("LogInfo", _queue);

                        break;
                    }

                    projectsInfo.Clear();

                    throw new Exception("Proje kodu veya şifresi yanlış");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Consume(int ConsumePass)
        {
            if (ConsumePass == 1)
            {
                for (; ; )
                {

                    Consumer _consumer = new Consumer("LogInfo");
                    if (_consumer._queue != null)
                    {
                        LogInfo logInfos = new LogInfo
                        {
                            LogInfoMessage = _consumer._queue,

                        };

                        using (LogDbContext db = new LogDbContext())
                        {
                            db.Add(logInfos);

                            db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}