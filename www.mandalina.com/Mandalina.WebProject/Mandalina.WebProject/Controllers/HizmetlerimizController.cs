using Mandalina.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;

namespace Mandalina.WebProject.Controllers
{
    public class HizmetlerimizController : BaseController
    {
        DataBaseContext db = new DataBaseContext();
        // GET: Hizmetlerimiz
        public ActionResult Index(string Seolink)
        {
            Meta();
            //Seolink = Request.Url.AbsolutePath;
            var detay = db.Service.Include(x => x.Work).Where(x => x.Slug == Seolink).FirstOrDefault();
            var Details = db.Work.Include(x => x.Service).Include(y => y.WorkImages).Where(x => x.Service.Slug == Seolink && x.Service.LanguageId == 1).ToList().OrderBy(x=>x.Rank);
            return View(detay);
        }
    }
}