using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.DTO.Request
{
    public class InsertLogRequest
    {
        public string ProjectCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsRequestEmail { get; set; }
        public string LogInfoMessage { get; set; }
        public string queuName { get; set; }
    }
}
