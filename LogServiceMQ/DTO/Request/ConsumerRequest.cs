using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.DTO.Request
{
    public class ConsumerRequest
    {
        public string ProjectCode { get; set; }
        public string queuName { get; set; }
    }
}
