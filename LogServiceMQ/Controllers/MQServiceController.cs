using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogService.DomainClasses;
using LogService.DTO;
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

        [HttpPost]
        [Route("InsertLog")]
        public async Task InsertLog(InsertLogRequest request)
        {
            //todo : database e proje tablosu eklenmeli bu tabloda projeno ve code alanı olmalı
            //gelen request eğer dbde bir projeye denk gelmiyorsa hata donulmeli


            try
            {

                _queue = request.LogInfo;
                Publisher publisher = new Publisher("LogInfo", _queue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("Consume")]
        public void Consume()
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