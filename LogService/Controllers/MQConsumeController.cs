using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogService.DomainClasses;
using LogService.MQService;
using LogService.MyDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQConsumeController : ControllerBase
    {
        public void Consume(int ConsumePass)
        {
            if (ConsumePass == 1)
            {
                for (; ; )
                {

                    Consumer _consumer = new Consumer("LogInfo");
                    if (_consumer._queue!=null)
                    {
                        List<LogInfo> logInfos = new List<LogInfo>();
                        new LogInfo()
                        {
                            LogInfoMessage = _consumer._queue

                        };

                        LogDbContext logDbContext = new LogDbContext()
                        logDbContext.SaveChanges();
                        
                    }


                    
                }
            }


        }



    }
}