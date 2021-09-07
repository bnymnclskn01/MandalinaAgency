using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Mandalina.DAL;
using Mandalina.Entities;

namespace Mandalina.WebProject.Areas.Panel.Controllers
{
    public class AboutUsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/AboutUs
        public ActionResult Index()
        {
            var aboutUs = db.AboutUs.Include(a => a.Language);
            return View(aboutUs.ToList());
        }

        // GET: Panel/AboutUs/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/AboutUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(AboutUs aboutUs, HttpPostedFileBase ImageUrl)
        {
            var AU = db.AboutUs.Count();
            if (ModelState.IsValid)
            {
                if (AU < 2)
                {
                    if (ImageUrl != null)
                    {
                        WebImage img = new WebImage(ImageUrl.InputStream);
                        FileInfo imginfo = new FileInfo(ImageUrl.FileName);
                        string aboutImaging = Guid.NewGuid().ToString() + imginfo.Extension;
                        img.Resize(1920, 1080);
                        img.Save("~/Images/AboutUs/" + aboutImaging);
                        aboutUs.ImageUrl = "/Images/AboutUs/" + aboutImaging;
                    }
                    aboutUs.IsActiveted = true;
                    aboutUs.IsDeleted = false;
                    aboutUs.LastDateTime = DateTime.Now;
                    db.AboutUs.Add(aboutUs);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Mesaj = "En az bir adet hakkımızda girişi yapabilirsiniz";
                    ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", aboutUs.LanguageId);
                    return View(aboutUs);
                }

            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", aboutUs.LanguageId);
            return View(aboutUs);
        }

        // GET: Panel/AboutUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = db.AboutUs.Include(x => x.Language).Where(x => x.Id == id).FirstOrDefault();
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", aboutUs.LanguageId);
            return View(aboutUs);
        }

        // POST: Panel/AboutUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int Id, AboutUs aboutUs, HttpPostedFileBase ImageUrl)
        {
            var AU = db.AboutUs.Include(x => x.Language).Where(x => x.Id == Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(AU.ImageUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(AU.ImageUrl));
                    }
                    WebImage img = new WebImage(ImageUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ImageUrl.FileName);
                    string aboutUsImaging = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1920, 1080);
                    img.Save("~/Images/AboutUs/" + aboutUsImaging);
                    AU.ImageUrl = "/Images/AboutUs/" + aboutUsImaging;
                }
                AU.Id = aboutUs.Id;
                AU.AboutUsContent = aboutUs.AboutUsContent;
                AU.IsActiveted = true;
                AU.IsDeleted = false;
                AU.LanguageId = aboutUs.LanguageId;
                AU.LastDateTime = DateTime.Now;
                AU.MainTitle = aboutUs.MainTitle;
                AU.MissionContent = aboutUs.MissionContent;
                AU.Title = aboutUs.Title;
                AU.VisionContent = aboutUs.VisionContent;
                db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", aboutUs.LanguageId);
            return View(aboutUs);
        }

        public ActionResult Delete(int Id)
        {
            AboutUs aboutUs = db.AboutUs.Find(Id);
            if (ModelState.IsValid)
            {
                if (System.IO.File.Exists(Server.MapPath(aboutUs.ImageUrl)))
                {
                    System.IO.File.Delete(Server.MapPath(aboutUs.ImageUrl));
                }
                db.AboutUs.Remove(aboutUs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutUs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
