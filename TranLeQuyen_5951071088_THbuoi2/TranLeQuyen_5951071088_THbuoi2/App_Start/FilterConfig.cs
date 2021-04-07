using System.Web;
using System.Web.Mvc;

namespace TranLeQuyen_5951071088_THbuoi2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
