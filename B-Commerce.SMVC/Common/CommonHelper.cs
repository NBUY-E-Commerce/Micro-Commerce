using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Common
{
    public class CommonHelper
    {

        //ınsan {name, surname
        public static T GetPropertyFromObject<T>(Type o, string propertyname)
        {

            T result = (T)o.GetProperty(propertyname).GetValue(null);

            return result;
        }
    }
}