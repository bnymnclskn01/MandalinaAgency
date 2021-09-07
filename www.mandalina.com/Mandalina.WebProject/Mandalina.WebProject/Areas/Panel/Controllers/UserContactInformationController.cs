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
    public class UserContactInformationController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/UserContactInformation
        public ActionResult Index()
        {
            var contactInformation = db.ContactInformation.Include(c => c.Language);
            return View(contactInformation.ToList());
        }

        // GET: Panel/UserContactInformation/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/UserContactInformation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactInformation contactInformation)
        {
            var ContactCount = db.ContactInformation.Where(x => x.IsActiveted == true && x.IsDeleted == false).Count();
            if (ModelState.IsValid)
            {
                if (ContactCount > 1)
                {
                    ViewBag.Mesaj = "En fazla 1 adet iletişim bilgisi ekleyebilirsiniz";
                    ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", contactInformation.LanguageId);
                    return View(contactInformation);
                }
                else
                {
                    contactInformation.IsDeleted = false;
                    contactInformation.IsActiveted = true;
                    contactInformation.LastDateTime = DateTime.Now;
                    db.ContactInformation.Add(contactInformation);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", contactInformation.LanguageId);
            return View(contactInformation);
        }

        // GET: Panel/UserContactInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInformation contactInformation = db.ContactInformation.Find(id);
            if (contactInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", contactInformation.LanguageId);
            return View(contactInformation);
        }

        // POST: Panel/UserContactInformation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, ContactInformation contactInformation)
        {
            var C = db.ContactInformation.Find(Id);
            if (ModelState.IsValid)
            {
                C.Id = contactInformation.Id;
                C.Address = contactInformation.Address;
                C.Address2 = contactInformation.Address2;
                C.FaxNumber = contactInformation.FaxNumber;
                C.IsActiveted = contactInformation.IsActiveted;
                C.IsDeleted = contactInformation.IsDeleted;
                C.LanguageId = contactInformation.LanguageId;
                C.LastDateTime = DateTime.Now;
                C.Mail = contactInformation.Mail;
                C.PhoneNumber = contactInformation.PhoneNumber;
                C.PhoneNumber2 = contactInformation.PhoneNumber2;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", contactInformation.LanguageId);
            return View(contactInformation);
        }

        // GET: Panel/UserContactInformation/Delete/5
        public ActionResult Delete(int id)
        {
            ContactInformation contactInformation = db.ContactInformation.Find(id);
            if (ModelState.IsValid)
            {
                db.ContactInformation.Remove(contactInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactInformation);
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
