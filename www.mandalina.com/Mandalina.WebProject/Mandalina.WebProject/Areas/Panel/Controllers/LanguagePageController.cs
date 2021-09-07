using Mandalina.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mandalina.WebProject.Areas.Panel.Controllers
{
    public class LanguagePageController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        // GET: Panel/LanguagePage
        public ActionResult Index()
        {
            return View(db.Languages.ToList());
        }
    }
}