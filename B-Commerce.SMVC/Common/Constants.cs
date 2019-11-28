using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Common
{
    public class Constants
    {
        public const string LOGIN_API_BASE_URI = "http://localhost:59282/";
        public const string LOGIN_API_LOGIN_URI = "/api/Login/Login";
        public const string LOGIN_API_REGISTER_URI = "/api/Login/UserRegistry";
        public const string LOGIN_API_CHECK_VERIFICATION_URI = "/api/Login/CheckVerificationCode";
        public const string LOGIN_API_FACEBOOK_URI = "/api/Login/FacebookLogin";

        public const int LOGIN_RESPONSE_SUCCESS = 0;


    }
}