using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Common
{
    public class UserAdmin
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public string Token { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsValid { get; set; }

        public List<string> Roles { get; set; }


        public static UserAdmin CurrentUserAdmin
        {
            get
            {
                if (HttpContext.Current.Session["useradmin"] == null)
                {
                    return null;
                }

                return (UserAdmin)HttpContext.Current.Session["useradmin"];

            }
            set
            {
                HttpContext.Current.Session["useradmin"] = value;

            }
        }
    }
}