using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mandalina.WebProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                   name: "Anasayfa",
                   url: "",
                   defaults: new { controller = "Home", action = "Index", LangCode = "tr" }
               );
            routes.MapRoute(
                   name: "Hakkımızda",
                   url: "hakkimizda",
                   defaults: new { controller = "About", action = "Index", LangCode = "tr" }
               );
            routes.MapRoute(
                   name: "İşler",
                   url: "portfolyo",
                   defaults: new { controller = "Work", action = "Index", LangCode = "tr" }
               );
            routes.MapRoute(
                   name: "İşlerDetayi",
                   url: "portfolyo/{SeoLink}",
                   defaults: new { controller = "Hizmetlerimiz", action = "Index", LangCode = "tr", SeoLink= UrlParameter.Optional }
               );
            routes.MapRoute(
                   name: "İletisim",
                   url: "iletisim",
                   defaults: new { controller = "Contact", action = "Index"}
               );
            routes.MapRoute(
                   name: "Default",
                   url: "{controller}/{action}" // Bu olmazsa Action Controller yazarak çalışamazsın yani render kullanamazsın.
               );
            #region PartialView
            routes.MapRoute(
                   name: "PartialSliderList",
                   url: "PartialSliderList",
                   defaults: new { controller = "Home", action = "PartialSliderList" }
               );
            routes.MapRoute(
                   name: "PartailConstantValueSlider",
                   url: "PartailConstantValueSlider",
                   defaults: new { controller = "Home", action = "PartailConstantValueSlider" }
               );
            routes.MapRoute(
                   name: "PartialCategoryList",
                   url: "PartialCategoryList",
                   defaults: new { controller = "Home", action = "PartialCategoryList" }
               );
            routes.MapRoute(
                   name: "PartialServiceList",
                   url: "PartialServiceList",
                   defaults: new { controller = "Home", action = "PartialServiceList" }
               );
            routes.MapRoute(
                   name: "TRPartialCategoryList",
                   url: "TRPartialCategoryList",
                   defaults: new { controller = "Work", action = "TRPartialCategoryList" }
               );
            routes.MapRoute(
                   name: "TRPartialService",
                   url: "TRPartialService",
                   defaults: new { controller = "Work", action = "TRPartialService" }
               );
            routes.MapRoute(
                   name: "PartialConstantValueWork",
                   url: "PartialConstantValueWork",
                   defaults: new { controller = "Work", action = "PartialConstantValueWork" }
               );
            routes.MapRoute(
                   name: "PartialConstantValueWork2",
                   url: "PartialConstantValueWork2",
                   defaults: new { controller = "Work", action = "PartialConstantValueWork2" }
               );
            routes.MapRoute(
                   name: "PartialConstantValueHomeWorks",
                   url: "PartialConstantValueHomeWorks",
                   defaults: new { controller = "Home", action = "PartialConstantValueHomeWorks" }
               );
            routes.MapRoute(
                   name: "PartialConstantValueHomeWorks2",
                   url: "PartialConstantValueHomeWorks2",
                   defaults: new { controller = "Home", action = "PartialConstantValueHomeWorks2" }
               );
            routes.MapRoute(
                   name: "PartialContsantValueContactTitle",
                   url: "PartialContsantValueContactTitle",
                   defaults: new { controller = "Contact", action = "PartialConstantValueHomeWorks2" }
               );
            routes.MapRoute(
                   name: "PartialContsantValueContactInformationTitle",
                   url: "PartialContsantValueContactInformationTitle",
                   defaults: new { controller = "Contact", action = "PartialContsantValueContactInformationTitle" }
               );
            routes.MapRoute(
                   name: "PartialContsantValueContactFormTitle",
                   url: "PartialContsantValueContactFormTitle",
                   defaults: new { controller = "Contact", action = "PartialContsantValueContactFormTitle" }
               );
            routes.MapRoute(
                   name: "PartialSocialMediaList",
                   url: "PartialSocialMediaList",
                   defaults: new { controller = "Home", action = "PartialSocialMediaList" }
               );
            #endregion
        }
    }
}
