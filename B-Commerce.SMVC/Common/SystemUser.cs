using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Common
{
    public class SystemUser
    {

        public string Email { get; set; }
        public string Name { get; set; }

        public string Token { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsValid { get; set; }

        public static SystemUser CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["user"] == null)
                {
                    return null;
                }

                return (SystemUser)HttpContext.Current.Session["user"];

            }
            set
            {
                HttpContext.Current.Session["user"] = value;

            }
        }



    }
}