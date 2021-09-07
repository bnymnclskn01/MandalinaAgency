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
    public class MenusPageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/Menus
        public ActionResult Index()
        {
            var menu = db.Menuler.Include(m => m.Language);
            return View(menu.Where(x=>x.IsDeleted==false && x.IsActiveted==true).ToList());
        }

        // GET: Panel/Menus/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menuler menus)
        {
            if (ModelState.IsValid)
            {
                menus.PropertyId = 0;
                menus.IsDeleted = false;
                menus.LastDateTime = DateTime.Now;
                db.Menuler.Add(menus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", menus.LanguageId);
            return View(menus);
        }

        // GET: Panel/Menus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menuler menuler = db.Menuler.Find(id);
            if (menuler == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", menuler.LanguageId);
            return View(menuler);
        }

        // POST: Panel/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Menuler menus)
        {
            var M = db.Menuler.Find(Id);
            if (ModelState.IsValid)
            {
                M.Id = menus.Id;
                M.IsActiveted = menus.IsActiveted;
                M.IsDeleted = menus.IsDeleted;
                M.IsFooter = menus.IsFooter;
                M.IsSmallFooter = menus.IsSmallFooter;
                M.IsUnderFooter = menus.IsUnderFooter;
                M.LanguageId = menus.LanguageId;
                M.LastDateTime = DateTime.Now;
                M.Name = menus.Name;
                M.PropertyId = 0;
                M.Rank = menus.Rank;
                M.UrlPath = menus.UrlPath;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", menus.LanguageId);
            return View(menus);
        }

        public ActionResult Delete(int ID)
        {
            Menuler menuler = db.Menuler.Find(ID);
            if (ModelState.IsValid)
            {
                db.Menuler.Remove(menuler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuler);
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
