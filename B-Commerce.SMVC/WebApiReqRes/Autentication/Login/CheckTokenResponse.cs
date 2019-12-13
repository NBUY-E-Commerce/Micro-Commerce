using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.WebApiReqRes.Autentication.Login
{
    public class CheckTokenResponse : CommonResponse
    {


        public string Username { get; set; }
        public int UserID { get; set; }

        public DateTime ExpireDate { get; set; }

    }
}