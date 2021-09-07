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
    public class ConstantValueController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/ConstantValue
        public ActionResult Index()
        {
            var constantValue = db.ConstantValue.Include(c => c.Language);
            return View(constantValue.ToList());
        }
        // GET: Panel/ConstantValue/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/ConstantValue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConstantValues constantValues)
        {
            if (ModelState.IsValid)
            {
                constantValues.IsDeleted = false;
                constantValues.LastDateTime = DateTime.Now;
                db.ConstantValue.Add(constantValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", constantValues.LanguageId);
            return View(constantValues);
        }

        // GET: Panel/ConstantValue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConstantValues constantValues = db.ConstantValue.Find(id);
            if (constantValues == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", constantValues.LanguageId);
            return View(constantValues);
        }

        // POST: Panel/ConstantValue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, ConstantValues constantValues)
        {
            var CV = db.ConstantValue.Find(Id);
            if (ModelState.IsValid)
            {
                CV.Id = constantValues.Id;
                CV.IsActiveted = constantValues.IsActiveted;
                CV.IsDeleted = constantValues.IsDeleted;
                CV.Key = constantValues.Key;
                CV.LanguageId = constantValues.LanguageId;
                CV.LastDateTime = DateTime.Now;
                CV.PageName = constantValues.PageName;
                CV.Value = constantValues.Value;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", constantValues.LanguageId);
            return View(constantValues);
        }

        // GET: Panel/ConstantValue/Delete/5
        public ActionResult Delete(int id)
        {
            ConstantValues constantValues = db.ConstantValue.Find(id);
            if (ModelState.IsValid)
            {
                db.ConstantValue.Remove(constantValues);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(constantValues);
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
