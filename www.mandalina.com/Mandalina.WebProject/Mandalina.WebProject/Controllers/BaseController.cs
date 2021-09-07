using Mandalina.BLL.Language;
using Mandalina.BLL.Seo;
using System;
using System.Web;
using System.Web.Mvc;

namespace Mandalina.WebProject.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public void CookieControl(string LangCode)
        {
            
            HttpCookie cookie = Request.Cookies["LanguageCode"];
            if (cookie.Value != LangCode && LangCode != null) //Gelen langcode cookiedeki valuedan farklıysa 
            {
                Request.Cookies.Remove("LanguageCode");
                HttpCookie cookieadd = new HttpCookie("LanguageCode");
                cookieadd.Value = LangCode.ToLower();
                cookieadd.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookieadd);
            }
        }

        public void MetaForHome(int id)
        {
            SeoManager seoManager = new SeoManager();
            var seo = seoManager.GetSeoSettings("/", id);
            if (seo != null)
            {
                ViewBag.Title = seo.Title;
                ViewBag.Keyword = seo.Keywords;
                ViewBag.Description = seo.Description;
            }
        }

        public void Meta()
        {
            SeoManager seoManager = new SeoManager();
            var seo = seoManager.GetSeoSettings(Request.Url.LocalPath);
            if (seo != null)
            {
                ViewBag.Title = seo.Title;
                ViewBag.Keyword = seo.Keywords;
                ViewBag.Description = seo.Description;
            }
        }
        public string GetCookieValue()  //String olarak cookie value almamız için
        {
            HttpCookie cookie = Request.Cookies["LanguageCode"];
            return cookie.Value;
        }

        public int GetLanguageIdByLangCode() //Langcode a göre lang id getirir
        {
            LanguageManager languageManager = new LanguageManager();

            int langId = languageManager.GetLanguageId(GetCookieValue());
            return langId;
        }

    }
}