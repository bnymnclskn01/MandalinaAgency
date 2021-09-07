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
    public class CategoryPageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/CategoryPage
        public ActionResult Index()
        {
            var category = db.Category.Include(c => c.Language);
            return View(category.ToList());
        }

        // GET: Panel/CategoryPage/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/CategoryPage/Create
        //Id,Name,Note,Content,Rank,CategorySlug,RawSlug,LanguageId,LastDateTime,IsActiveted,IsDeleted
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                categories.IsDeleted = false;
                categories.LastDateTime = DateTime.Now;
                db.Category.Add(categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", categories.LanguageId);
            return View(categories);
        }

        // GET: Panel/CategoryPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = db.Category.Find(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", categories.LanguageId);
            return View(categories);
        }

        // POST: Panel/CategoryPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Categories categories)
        {
            var C = db.Category.Find(Id);
            if (ModelState.IsValid)
            {
                C.Id = categories.Id;
                C.CategorySlug = categories.CategorySlug;
                C.Content = categories.Content;
                C.IsActiveted = categories.IsActiveted;
                C.IsDeleted = categories.IsDeleted;
                C.LanguageId = categories.LanguageId;
                C.LastDateTime = DateTime.Now;
                C.Name = categories.Name;
                C.Note = categories.Note;
                C.Rank = categories.Rank;
                C.RawSlug = categories.RawSlug;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", categories.LanguageId);
            return View(categories);
        }


        public ActionResult Delete(int Id)
        {
            Categories categories = db.Category.Find(Id);
            if (ModelState.IsValid)
            {
                db.Category.Remove(categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);
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
