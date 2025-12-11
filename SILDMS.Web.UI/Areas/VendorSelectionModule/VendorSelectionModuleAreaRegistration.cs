using System.Web.Mvc;

namespace SILDMS.Web.UI.Areas.VendorSelectionModule
{
    public class VendorSelectionModuleAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VendorSelectionModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VendorSelectionModule_default",
                "VendorSelectionModule/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}