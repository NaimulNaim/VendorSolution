using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.CBPSModule
{
    public class CBPSModuleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CBPSModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CBPSModule_default",
                "CBPSModule/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}