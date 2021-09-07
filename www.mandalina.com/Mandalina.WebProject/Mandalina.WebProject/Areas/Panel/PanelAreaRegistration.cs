using System.Web.Mvc;

namespace Mandalina.WebProject.Areas.Panel
{
    public class PanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Panel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            
            context.MapRoute(
                "Panel_default",
                "Panel/{controller}/{action}/{id}",
                new { controller= "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "ConstantValuesPage",
                "Panel/{controller}/{action}/{id}",
                new { controller = "ConstantValuesPage", action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "ConstantValuesPage2",
                "Panel/{controller}/{action}/{id}",
                new { controller = "ConstantValuesPage", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}