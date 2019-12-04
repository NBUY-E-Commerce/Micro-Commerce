using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
    public static class MyHelper
    {

        public static MvcHtmlString GetBannerItem(this HtmlHelper htmlHelper, int bannerType,int? relatedID,string imageurl,string description)
        {


            string item = "<a href='";

            switch (bannerType)
            {
                case 1:
                    item += "/Product/Detail/" + relatedID;
                    break;
                case 2:
                    item += "/Category/Products/" + relatedID;
                    break;
                   
                default:
                    break;
            }

            item += "'>";

           
            item += $"<img src='{imageurl}' alt='{ description}' class='img-fluid'></a>";

            return new MvcHtmlString(item);
        }

    }
}