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
    public class WorkController : BaseController
    {
        // GET: Work
        private DataBaseContext db = new DataBaseContext();
        #region TR
        public ActionResult Index()
        { 
            Meta();
            return View();
        }
        public ActionResult TRPartialService()
        {
            var service = db.Service.Include(x => x.Language).Include(x => x.Category).Where(x => x.LanguageId == 1 && x.IsActiveted == true && x.IsDeleted == false).ToList().OrderBy(x => x.Rank);
            return PartialView(service);
        }
        public ActionResult TRPartialCategoryList()
        {
            var category = db.Category.Include(x => x.Language).Where(x => x.LanguageId == 1 && x.IsActiveted == true && x.IsDeleted == false).ToList().OrderBy(x => x.Rank);
            return PartialView(category);
        }
        public ActionResult PartialConstantValueWork()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "portfolyo").FirstOrDefault());
        }
        public ActionResult PartialConstantValueWork2()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "portfolyo-sub-title").FirstOrDefault());
        }
        #endregion
    }
}