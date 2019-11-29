using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.DTO
{
    public class InsertLogRequest
    {
        public int ProjectCode { get; set; }

        public string ProjectPassword { get; set; }

        public string LogInfo { get; set; }

  

    }
}
