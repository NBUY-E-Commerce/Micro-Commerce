using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Common
{
    public class Constants
    {
        //Facebook
        public const string FACEBOOK_APPID = "3462488800442988";
        public const string FACEBOOK_APPSECRET = "2f5eb5daf3ea0fea4c09e729b1b379d7";
        public const string MVC_FACEBOOK_URI = "https://localhost:44314/Login/FacebookLogin";//MVC FB URL

        //LoginAPI
        public const string LOGIN_API_BASE_URI = "https://localhost:44311/";//LoginApideki SSL Aktifleştirildi
        public const string LOGIN_API_LOGIN_URI = "/api/Login/Login";
        public const string LOGIN_API_REGISTER_URI = "/api/Login/UserRegistry";
        public const string LOGIN_API_CHECK_VERIFICATION_URI = "/api/Login/CheckVerificationCode";
        public const string LOGIN_API_FACEBOOK_URI = "/api/Login/FacebookLogin";

        public const int LOGIN_RESPONSE_SUCCESS = 0;


    }
}