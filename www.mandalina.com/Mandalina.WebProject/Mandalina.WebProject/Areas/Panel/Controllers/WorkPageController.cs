using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mandalina.DAL;
using Mandalina.Entities;

namespace Mandalina.WebProject.Areas.Panel.Controllers
{
    public class WorkPageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/WorkPage
        public ActionResult Index()
        {
            var work = db.Work.Include(w => w.Service);
            return View(work.ToList());
        }

        public ActionResult List(int Id)
        {
            return View(db.WorkImages.Include(x => x.Work).Where(x => x.WorkID == Id).ToList());
        }
        
        // GET: Panel/WorkPage/Create
        public ActionResult Create()
        {
            ViewBag.ServiceId = new SelectList(db.Service.Where(x=>x.IsActiveted==true), "Id", "serviceTitle");
            return View();
        }

        // POST: Panel/WorkPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Work work, IEnumerable<HttpPostedFileBase> ImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (work.OneImage == false && work.TwoImage == false && work.ThreeImage == false)
                {
                    ViewBag.Mesaj = "Lütfen En Az Bir Tane Seçim Yapınız.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (work.OneImage == false && work.TwoImage == true && work.ThreeImage == true)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (work.OneImage == true && work.TwoImage == false && work.ThreeImage == true)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (work.OneImage == true && work.TwoImage == true && work.ThreeImage == false)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (work.OneImage == true && work.TwoImage == true && work.ThreeImage == true)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else
                {
                    work.IsDeleted = false;
                    work.LastDateTime = DateTime.Now;
                    db.Work.Add(work);
                    db.SaveChanges();
                    foreach (var item in ImageUrl)
                    {
                        WorkImage img = new WorkImage();
                        string photoName = Path.GetFileName(Guid.NewGuid().ToString() + item.FileName);
                        var url = Path.Combine(Server.MapPath("~/Images/Service/" + photoName));
                        img.ImageUrl = photoName;
                        item.SaveAs(url);
                        img.WorkID = work.Id;
                        img.IsActiveted = true;
                        img.IsDeleted = false;
                        img.LastDateTime = DateTime.Now;
                        db.WorkImages.Add(img);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
            return View(work);
        }

        // GET: Panel/WorkPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work work = db.Work.Find(id);
            if (work == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
            return View(work);
        }

        // POST: Panel/WorkPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int Id, Work work)
        {
            var W = db.Work.Find(Id); W.Id = work.Id;
            if (ModelState.IsValid)
            {
                if (work.OneImage == false && work.TwoImage == false && work.ThreeImage == false)
                {
                    ViewBag.Mesaj = "Lütfen En Az Bir Tane Seçim Yapınız.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (work.OneImage == false && work.TwoImage == true && work.ThreeImage == true)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (W.OneImage == true && W.TwoImage == false && W.ThreeImage == true)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (work.OneImage == true && work.TwoImage == true && work.ThreeImage == false)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else if (work.OneImage == true && work.TwoImage == true && work.ThreeImage == true)
                {
                    ViewBag.Mesaj = "Lütfen Sadece Bir Tane Aktif Alan Seçmeniz Gerekir.";
                    ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
                    return View(work);
                }
                else
                {
                    W.IsActiveted = work.IsActiveted;
                    W.IsDeleted = work.IsDeleted;
                    W.LastDateTime = DateTime.Now;
                    W.Name = work.Name;
                    W.Rank = work.Rank;
                    W.Content = work.Content;
                    W.Content2 = work.Content2;
                    W.Content3 = work.Content3;
                    W.ServiceId = work.ServiceId;
                    W.OneImage = work.OneImage;
                    W.ThreeImage = work.ThreeImage;
                    W.TwoImage = work.TwoImage;
                    W.TextIsActive = work.TextIsActive;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ServiceId = new SelectList(db.Service.Where(x => x.IsActiveted == true), "Id", "serviceTitle", work.ServiceId);
            return View(work);
        }


        public ActionResult Delete(int Id)
        {
            Work work = db.Work.Find(Id);
            if (ModelState.IsValid)
            {
                db.Work.Remove(work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work);
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
