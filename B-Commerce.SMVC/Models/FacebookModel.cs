using B_Commerce.SMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class FacebookModel
    {
        public FacebookModel()
        {
            AppID = Constants.FACEBOOK_APPID;
            AppSecret = Constants.FACEBOOK_APPSECRET;
            FacebookUri = Constants.MVC_FACEBOOK_URI;
        }
        public string FacebookCode { get; set; }
        public string AppID { get; set; }
        public string AppSecret { get; set; }
        public string FacebookUri { get; set; }
    }
}