using Mandalina.DAL;
using System.Data.Entity;
using System.Web.Mvc;
using System.Data;
using System.Linq;

namespace Mandalina.WebProject.Controllers
{
    // #e63911
    public class HomeController : BaseController
    {
        DataBaseContext db = new DataBaseContext();
        #region TR
        public ActionResult Index()
        {
            Meta();
            return View();
        }
        public ActionResult PartialSliderList()
        {
            return PartialView(db.VideoPlayer.Where(x => x.IsActiveted == true && x.IsDeleted == false).ToList().OrderBy(x=>x.Rank));
        }
        public ActionResult PartailConstantValueSlider()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "SliderText").FirstOrDefault());
        }
        public ActionResult PartialCategoryList()
        {
            return PartialView(db.Category.Where(x => x.IsActiveted == true && x.IsDeleted == false).ToList());
        }
        public ActionResult PartialServiceList()
        {
            return PartialView(db.Service.Include(x => x.Category).Where(x => x.IsActiveted == true && x.IsDeleted == false && x.IsMainActive==true).ToList());
        }
        public ActionResult PartialConstantValueHomeWorks()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "anasayfa-work").FirstOrDefault());
        }
        public ActionResult PartialConstantValueHomeWorks2()
        {
            return PartialView(db.ConstantValue.Where(x => x.Key == "anasayfa-work-2").FirstOrDefault());
        }
        public ActionResult PartialSocialMediaList()
        {
            return PartialView(db.SocialMedias.Where(x => x.IsActiveted == true && x.IsDeleted == false).ToList().OrderBy(x => x.Rank));
        }
        #endregion
    }
}