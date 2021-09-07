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
    public class AboutController : BaseController
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: About
        #region TR
        public ActionResult Index()
        {
            var about = db.AboutUs.Include(x => x.Language).Where(x => x.IsActiveted == true && x.LanguageId == 1 && x.IsDeleted == false).FirstOrDefault();
            Meta();
            return View(about);
        }
        //public ActionResult TRPartialConstantValue()
        //{
        //    var constant = db.ConstantValue.Include(x => x.Language).Where(x => x.LanguageId == 1 && x.PageName == "hakkimizda" && x.IsActiveted == true && x.IsDeleted == false).ToList();
        //    return PartialView(constant);
        //}
        #endregion
    }
}