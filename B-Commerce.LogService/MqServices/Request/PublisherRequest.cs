using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.LogService.MqServices.Request
{
    public class PublisherRequest
    {
        public string ProjectId { get; set; }
        public string LoginInfoMessage { get; set; }
        public string Email { get; set; }
        public bool IsEmailRequired { get; set; }
    }
}
