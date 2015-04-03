using System.Web;
using System.Web.Mvc;
using BSPN.Security;

namespace BSPN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
