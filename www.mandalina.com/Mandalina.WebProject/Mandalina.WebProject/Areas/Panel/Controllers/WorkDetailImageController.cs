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
    public class WorkDetailImageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/WorkDetailImage
        public ActionResult Index()
        {
            var workImages = db.WorkImages.Include(w => w.Work);
            return View(workImages.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.WorkID = new SelectList(db.Work, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(WorkImage workImage, HttpPostedFileBase ImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageUrl.FileName);
                    var url = Path.Combine(Server.MapPath("~/Images/Service/" + photoName));
                    ImageUrl.SaveAs(url);
                    workImage.ImageUrl = photoName;
                }
                workImage.IsActiveted = true;
                workImage.IsDeleted = false;
                workImage.LastDateTime = DateTime.Now;
                db.WorkImages.Add(workImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkID = new SelectList(db.Work, "Id", "Name", workImage.WorkID);
            return View(workImage);
        }
        // GET: Panel/WorkDetailImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkImage workImage = db.WorkImages.Find(id);
            if (workImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkID = new SelectList(db.Work, "Id", "Name", workImage.WorkID);
            return View(workImage);
        }

        // POST: Panel/WorkDetailImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, WorkImage workImage, HttpPostedFileBase ImageUrl)
        {
            var W = db.WorkImages.Find(Id);
            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Images/Service/" + W.ImageUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/Service" + W.ImageUrl));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + ImageUrl.FileName);
                    var url = Path.Combine(Server.MapPath("~/Images/Service/" + photoName));
                    W.ImageUrl = photoName;
                    ImageUrl.SaveAs(url);
                }
                W.IsActiveted = workImage.IsActiveted;
                W.WorkID = workImage.WorkID;
                W.IsDeleted = workImage.IsDeleted;
                W.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkID = new SelectList(db.Work, "Id", "Name", workImage.WorkID);
            return View(workImage);
        }

        // GET: Panel/WorkDetailImage/Delete/5
        public ActionResult Delete(int id)
        {
            WorkImage workImage = db.WorkImages.Find(id);
            if (ModelState.IsValid)
            {
                if (System.IO.File.Exists(Server.MapPath("/Images/Service/" + workImage.ImageUrl)))
                {
                    System.IO.File.Delete(Server.MapPath("/Images/Service/" + workImage.ImageUrl));
                }
                db.WorkImages.Remove(workImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workImage);
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
