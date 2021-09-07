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
    public class UserContactFormController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/UserContactForm
        public ActionResult Index()
        {
            var contactForm = db.ContactForm.Include(c => c.Language);
            return View(contactForm.ToList());
        }

        // GET: Panel/UserContactForm/Delete/5
        public ActionResult Delete(int id)
        {
            ContactForm contactForm = db.ContactForm.Find(id);
            if (ModelState.IsValid)
            {
                db.ContactForm.Remove(contactForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactForm);
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
