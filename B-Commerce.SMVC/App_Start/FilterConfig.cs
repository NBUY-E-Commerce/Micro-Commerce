using B_Commerce.SMVC.FilterHelper.Filters;
using System.Web;
using System.Web.Mvc;

namespace B_Commerce.SMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
          
        }
    }
}
