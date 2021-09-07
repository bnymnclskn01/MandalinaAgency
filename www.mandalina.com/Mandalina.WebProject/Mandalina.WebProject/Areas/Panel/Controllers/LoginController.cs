using Mandalina.BLL.LoginManager;
using Mandalina.DAL;
using Mandalina.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mandalina.WebProject.Areas.Panel.Controllers
{
    public class LoginController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        // GET: Panel/Login
        public ActionResult Index(bool? IsOkey)
        {
            if (IsOkey == false)
            {
                ViewBag.ErrorMessage = "Lütfen kullanıcı adınızı veya şifrenizi doğru giriniz.";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Username, string Password)
        {
            var data = db.Member.Where(x => x.UserName == Username && x.Password == Password).ToList();
            if (data.Count == 1)
            {
                Session["Admin"] = data.FirstOrDefault();
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                Session["User"] = null;
                ViewBag.ErrorMessage = "Lütfen şifrenizi veya kullanıcı adınızı doğru girdiğinizden emin olunuz.";
                return RedirectToAction("Index", new { isOkey = false });
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}