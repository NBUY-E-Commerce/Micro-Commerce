using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace B_Commerce.SMVC.Common
{
    public static class MUriHelper
    {
        public static string AddQueryStringItemToUrl(string key,string value)
        {
            string baselink = HttpContext.Current.Request.Path;
            int count = 1;
            foreach (string querykey in HttpContext.Current.Request.QueryString.Keys)
            {
                if (querykey != key)
                {
                    if (count == 1)
                    {
                        baselink += "?" + querykey + "=" + HttpContext.Current.Request.QueryString[querykey];

                    }
                    else
                    {
                        baselink += "&" + querykey + "=" + HttpContext.Current.Request.QueryString[querykey];
                    }
                    count++;
                }
            }
            if (baselink.Contains("?")) baselink += "&";
            else baselink += "?";

            if(!string.IsNullOrEmpty(value))
            {

                baselink += key + "=" + value;
            }

            return baselink;

        }

        public static string GenerateSlug(string phrase)
        {
            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveAccent(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}