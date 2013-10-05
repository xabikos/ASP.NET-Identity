using System.Web;
using System.Web.Mvc;

namespace Asp.Identity.EntityFramework.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
