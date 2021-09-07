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
using Mandalina.Core.Helper;
using Mandalina.DAL;
using Mandalina.Entities;

namespace Mandalina.WebProject.Areas.Panel.Controllers
{
    public class ServicePageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/ServicePage
        public ActionResult Index()
        {
            var service = db.Service.Include(s => s.Category).Include(s => s.Language);
            return View(service.ToList());
        }

        // GET: Panel/ServicePage/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category.Where(x=>x.IsActiveted==true), "Id", "Name");
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/ServicePage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Service service, HttpPostedFileBase ImageUrl)
        {
            var S = db.Service.Where(x => x.serviceTitle.ToLower().ToUpper() == service.serviceTitle.ToLower().ToUpper()).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (S != null)
                {
                    ViewBag.Mesaj = "Bu başlıkta sistemde var olan kayıt olduğu için yeni ekleme yapamıyoruz";
                    ViewBag.CategoryId = new SelectList(db.Category.Where(x => x.IsActiveted == true), "Id", "Name", service.CategoryId);
                    ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", service.LanguageId);
                    return View(service);
                }
                else
                {
                    if (ImageUrl != null)
                    {
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageUrl.FileName);
                        var url = Path.Combine(Server.MapPath("~/Images/Service/" + photoName));
                        service.ImageUrl = photoName;
                        ImageUrl.SaveAs(url);
                    }
                    service.IsDeleted = false;
                    service.LastDateTime = DateTime.Now;
                    if (service.LanguageId == 1)
                    {
                        service.Slug =StringHelper.StringReplacer(service.serviceTitle.ToLower() + service.serviceTitle2.ToLower());
                        service.RawSlug =StringHelper.StringReplacer(service.serviceTitle.ToLower() + service.serviceTitle2.ToLower());
                    }
                    else
                    {
                        service.Slug = StringHelper.StringReplacer(service.serviceTitle.ToLower() + service.serviceTitle2.ToLower());
                        service.RawSlug =StringHelper.StringReplacer(service.serviceTitle.ToLower() + service.serviceTitle2.ToLower());
                    }
                    db.Service.Add(service);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.CategoryId = new SelectList(db.Category.Where(x => x.IsActiveted == true), "Id", "Name", service.CategoryId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", service.LanguageId);
            return View(service);
        }

        // GET: Panel/ServicePage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category.Where(x => x.IsActiveted == true), "Id", "Name", service.CategoryId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", service.LanguageId);
            return View(service);
        }

        // POST: Panel/ServicePage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int Id, Service service, HttpPostedFileBase ImageUrl)
        {
            var S = db.Service.Find(Id);
            var SI = db.Service.Where(x => x.serviceTitle.ToLower().ToUpper() == service.serviceTitle.ToLower().ToUpper() && x.Id != Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (SI != null)
                {
                    ViewBag.Mesaj = "Bu başlıkta sistemde var olan kayıt olduğu için yeni güncelleme yapamıyoruz";
                    ViewBag.CategoryId = new SelectList(db.Category.Where(x => x.IsActiveted == true), "Id", "Name", service.CategoryId);
                    ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", service.LanguageId);
                    return View(service);
                }
                else
                {
                    if (ImageUrl != null)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/Images/Service/" + S.ImageUrl)))
                        {
                            System.IO.File.Delete(Server.MapPath("~/Images/Service" + S.ImageUrl));
                        }
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageUrl.FileName);
                        var url = Path.Combine(Server.MapPath("~/Images/Service/" + photoName));
                        S.ImageUrl = photoName;
                        ImageUrl.SaveAs(url);
                    }
                    S.CategoryId = service.CategoryId;
                    S.Id = service.Id;
                    S.IsActiveted = service.IsActiveted;
                    S.IsDeleted = service.IsDeleted;
                    S.LanguageId = service.LanguageId;
                    S.LastDateTime = DateTime.Now;
                    S.Rank = service.Rank;
                    S.IsMainActive = service.IsMainActive;
                    S.serviceCompany = service.serviceCompany;
                    S.serviceContent = service.serviceContent;
                    S.serviceContent2 = service.serviceContent2;
                    S.serviceTitle = service.serviceTitle;
                    S.serviceTitle2 = service.serviceTitle2;
                    if (service.LanguageId == 1)
                    {
                        S.Slug =StringHelper.StringReplacer(S.serviceTitle.ToLower() + S.serviceTitle2.ToLower());
                        S.RawSlug =StringHelper.StringReplacer(S.serviceTitle.ToLower() + S.serviceTitle2.ToLower());
                    }
                    else
                    {
                        S.Slug =StringHelper.StringReplacer(S.serviceTitle.ToLower() + S.serviceTitle2.ToLower());
                        S.RawSlug =StringHelper.StringReplacer(S.serviceTitle.ToLower() + S.serviceTitle2.ToLower());
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.Category.Where(x => x.IsActiveted == true), "Id", "Name", service.CategoryId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", service.LanguageId);
            return View(service);
        }


        public ActionResult Delete(int Id)
        {
            Service service = db.Service.Find(Id);
            if (ModelState.IsValid)
            {
                if (System.IO.File.Exists(Server.MapPath("/Images/Service/"+service.ImageUrl)))
                {
                    System.IO.File.Delete(Server.MapPath("/Images/Service/" + service.ImageUrl));
                }
                db.Service.Remove(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
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
