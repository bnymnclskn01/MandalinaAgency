using Mandalina.BLL.Language;
using Mandalina.BLL.Seo;
using Mandalina.Core.ViewModelForPanel.PanelPage.Seo;
using Mandalina.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Mandalina.WebProject.Areas.Panel.Controllers
{
    public class SeoPageController : Controller
    {
        SeoManager seoManager = new SeoManager();

        public ActionResult SeoSettingsList(string seoPageName, bool? updateStatus, bool? isExistInDb)
        {
            if (seoPageName != null)
            {
                ViewBag.Message = seoPageName + " kaydı başarılı bir şekilde güncellendi.";
            }

            if (isExistInDb == false)
            {
                ViewBag.ErrorMessage = " Güncellenecek bir kayıt bulunamadı.";
            }

            if (updateStatus == true)
            {
                ViewBag.ErrorMessage = " Kayıt başarılı bir şekilde güncellendi.";
            }


            var seoSettingsList = seoManager.SeoListForPanel();

            return View(seoSettingsList);
        }


        public ActionResult SeoAdd()
        {
            LanguageManager languageManager = new LanguageManager();

            var languageList = languageManager.GetLanguageList();

            return View(languageList);

        }

        [HttpPost]
        public ActionResult SeoAdd(SeoSaveForPanel model)
        {
            LanguageManager languageManager = new LanguageManager();

            var languageList = languageManager.GetLanguageList();

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Lütfen bilgileri eksiksiz doldurunuz.";

                return View(languageList);
            }

            else
            {
                SeoManager seoManager = new SeoManager();

                try
                {
                    int result = seoManager.AddSeo(model);

                    return RedirectToAction("SeoSettingsList", new { seoPageName = model.PageName });
                }
                catch (Exception ex)
                {

                    ViewBag.ErrorMessage = "Eklenirken bir hata oluştu. Hata kodu: " + ex.Message;

                    return View(languageList);
                }

            }

        }

        [HttpGet]
        public ActionResult UpdateSeoSettings(int id)
        {
            var seoSetting = seoManager.GetSeoUpdateForPanel(id);
            LanguageManager languageManager = new LanguageManager();
            seoSetting.LanguageList = null;
            seoSetting.LanguageList = languageManager.GetLanguageList();

            if (seoSetting == null)
            {
                return RedirectToAction("SeoSettingsList", new { isExistInDb = false });
            }

            else
            {
                return View(seoSetting);
            }


        }

        [HttpPost]
        public ActionResult UpdateSeoSettings(SeoUpdateForPanel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen bilgileri eksiksiz olarak doldurunuz.";

                return View(model);
            }

            else
            {
                var result = seoManager.SeoUpdateForPanel(model);

                if (result > 0)
                {
                    return RedirectToAction("SeoSettingsList", new { updateStatus = true });
                }

                else
                {
                    ViewBag.ErrorMessage = "Kayıt güncellenirken beklenmeyen bir hata meydana geldi.";

                    return View(model);
                }
            }
        }

        public ActionResult SeoDelete(int id)
        {
            SeoManager seoManager = new SeoManager();

            try
            {
                int result = seoManager.DeleteSeo(id);
                ViewBag.Message = "Başarıyla silinmiştir.";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Silinirken bir hata oluştu. Hata kodu: " + ex.Message;

                return RedirectToAction("SeoSettingsList");
            }

            return RedirectToAction("SeoSettingsList");
        }

        public ActionResult sitemap()
        {
            var siteadi = Request.Url.Scheme + "://" + Request.Url.Authority;

            string sitemapdosya = Server.MapPath("~/sitemap.xml");
            XmlTextWriter map = new XmlTextWriter(sitemapdosya, Encoding.UTF8);
            map.WriteStartDocument();
            map.WriteStartElement("urlset");
            map.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            map.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            map.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd");

            //map.WriteStartElement("url");
            //map.WriteElementString("loc", siteadi);
            //map.WriteElementString("lastmod", DateTime.Now.Date.ToString("yyyy-MM-dd"));
            //map.WriteElementString("changefreq", "daily");
            //map.WriteElementString("priority", "1");
            //map.WriteEndElement();

            //Sayfalar
            DataBaseContext db = new DataBaseContext();
            var sayfalar = db.SeoSetting.Where(x => x.IsActiveted == true && x.IsDeleted == false && x.LanguageId == 1).ToList();
            if (sayfalar.Count > 0)
            {
                foreach (var item in sayfalar)
                {
                    if (item.Url == "/")
                    {
                        map.WriteStartElement("url");
                        map.WriteElementString("loc", siteadi);
                        map.WriteElementString("lastmod", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                        map.WriteElementString("changefreq", "daily");
                        map.WriteElementString("priority", "1");
                        map.WriteEndElement();
                    }
                    else
                    {
                        map.WriteStartElement("url");
                        map.WriteElementString("loc", siteadi + item.Url);
                        map.WriteElementString("lastmod", DateTime.Now.Date.ToString("yyyy-MM-dd"));
                        map.WriteElementString("changefreq", "weekly");
                        map.WriteElementString("priority", "0.9");
                        map.WriteEndElement();
                    }

                }
            }
            map.WriteEndElement(); //urlset kapatması
            map.WriteEndDocument(); //dokuman kapatması
            map.Flush();
            map.Close();
            return RedirectToAction("SeoSettingsList", "SeoPage");
        }
    }
}