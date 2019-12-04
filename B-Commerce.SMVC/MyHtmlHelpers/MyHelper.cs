using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
    public static class MyHelper
    {

        public static MvcHtmlString GetBannerItem(this HtmlHelper htmlHelper, int bannerType, int? relatedID, string imageurl, string description)
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

        public static MvcHtmlString GetPager(this HtmlHelper htmlHelper, int currentPageIndex, int totalItems, int pageSize)
        {
            const int limit = 7; // toplam n sayfa elemanı 
            const int magicNumber = 4;

            string item = " <div class='pages'><nav aria-label = 'Page navigation example' class='d-flex justify-content-center'><ul class='pagination'> <li class='page - item'><a href='#' aria-label='Previous' class='page-link'><span aria-hidden='true'>«</span><span class='sr-only'>Previous</span></a></li>";


            int pageCount = totalItems / pageSize;

            if (totalItems % pageSize != 0)
            {
                pageCount++;
            }

            if (pageCount <= limit) //toplam sayfa sayısı 7ve küçükse
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    if (i == currentPageIndex)
                    {
                        item += $"<li class='page-item active'><a href = '#' class='page-link'>{i}</a></li>";
                    }
                    else
                    {
                        item += $"<li class='page-item'><a href = '#' class='page-link'>{i}</a></li>";
                    }
                }
            }

            else
            {

                if (currentPageIndex < magicNumber + 1) // ilk 4den biri aktif ise
                {
                    for (int i = 1; i <= magicNumber + 1; i++)
                    {
                        if (i == currentPageIndex)
                        {
                            item += $"<li class='page-item active'><a href = '#' class='page-link'>{i}</a></li>";
                        }
                        else
                        {
                            item += $"<li class='page-item'><a href = '#' class='page-link'>{i}</a></li>";
                        }
                    }
                    item += "<li class='page-item'><a class='page-link'>....</a></li>";

                    item += $"<li class='page-item'><a href = '#' class='page-link'>{pageCount}</a></li>";
                }

                else if (pageCount - currentPageIndex < magicNumber + 1) // son 4den biri aktif ise
                {
                    item += "<li class='page-item'><a href = '#' class='page-link'>1</a></li>";
                    item += "<li class='page-item'><a class='page-link'>....</a></li>";
                    for (int i = pageCount - magicNumber; i <= pageCount; i++)
                    {
                        if (i == currentPageIndex)
                        {
                            item += "<li class='page-item active'><a href = '#' class='page-link'>" + i + "</a></li>";
                        }
                        else
                        {
                            item += "<li class='page-item'><a href = '#' class='page-link'>" + i + "</a></li>";
                        }
                    }
                }
                else // genel
                {
                    item += "<li class='page-item'><a href = '#' class='page-link'>1</a></li>";
                    item += "<li class='page-item'><a class='page-link'>....</a></li>";

                    item += $"<li class='page-item'><a href = '#' class='page-link'>{currentPageIndex-1}</a></li>";
                    item += $"<li class='page-item active'><a href = '#' class='page-link'>{currentPageIndex}</a></li>";
                    item += $"<li class='page-item'><a href = '#' class='page-link'>{currentPageIndex + 1}</a></li>";

                    item += "<li class='page-item'><a class='page-link'>....</a></li>";
                    item += $"<li class='page-item'><a href = '#' class='page-link'>{pageCount}</a></li>";
                }



            }



            item += " <li class='page-item'><a href = '#' aria-label='Next' class='page-link'><span aria-hidden='true'>»</span><span class='sr-only'>Next</span></a></li></ul></nav></div>";

            return new MvcHtmlString(item);
        }
    }
}