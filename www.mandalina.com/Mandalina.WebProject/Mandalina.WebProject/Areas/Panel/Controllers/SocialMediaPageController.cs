using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mandalina.DAL;
using Mandalina.Entities;

namespace Mandalina.WebProject.Areas.Panel.Controllers
{
    public class SocialMediaPageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/SocialMediaPage
        public ActionResult Index()
        {
            var socialMedia = db.SocialMedias.Include(s => s.Language);
            return View(socialMedia.ToList());
        }


        // GET: Panel/SocialMediaPage/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/SocialMediaPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SocialMedias socialMedias)
        {
            if (ModelState.IsValid)
            {
                socialMedias.IsDeleted = false;
                socialMedias.LastDateTime = DateTime.Now;
                db.SocialMedias.Add(socialMedias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", socialMedias.LanguageId);
            return View(socialMedias);
        }

        // GET: Panel/SocialMediaPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialMedias socialMedias = db.SocialMedias.Find(id);
            if (socialMedias == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", socialMedias.LanguageId);
            return View(socialMedias);
        }

        // POST: Panel/SocialMediaPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, SocialMedias socialMedias)
        {
            var SM = db.SocialMedias.Find(Id);
            if (ModelState.IsValid)
            {
                SM.Id = socialMedias.Id;
                SM.IsActiveted = socialMedias.IsActiveted;
                SM.IsDeleted = socialMedias.IsDeleted;
                SM.LanguageId = socialMedias.LanguageId;
                SM.LastDateTime = DateTime.Now;
                SM.Link = socialMedias.Link;
                SM.Name = socialMedias.Name;
                SM.Rank = socialMedias.Rank;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", socialMedias.LanguageId);
            return View(socialMedias);
        }

        public ActionResult Delete(int Id)
        {
            SocialMedias socialMedias = db.SocialMedias.Find(Id);
            if (ModelState.IsValid)
            {
                db.SocialMedias.Remove(socialMedias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialMedias);
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
