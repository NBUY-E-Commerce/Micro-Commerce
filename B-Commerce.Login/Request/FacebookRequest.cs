using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.Request
{
    public class FacebookRequest
    {
        public string FacebookCode { get; set; }
        public string AppID { get; set; }
        public string AppSecret { get; set; }
        public string FacebookUri { get; set; }
    }
}
