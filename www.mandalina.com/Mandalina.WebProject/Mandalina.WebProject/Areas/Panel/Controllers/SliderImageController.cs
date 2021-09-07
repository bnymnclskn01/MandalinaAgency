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
    public class SliderImageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/SliderImage
        public ActionResult Index()
        {
            var sliderImage = db.SliderImage.Include(s => s.Slider);
            return View(sliderImage.ToList());
        }
        // GET: Panel/SliderImage/Create
        public ActionResult Create()
        {
            ViewBag.SliderId = new SelectList(db.Slider.Where(x=>x.IsActiveted==true && x.IsDeleted==false), "Id", "Title");
            return View();
        }

        // POST: Panel/SliderImage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SliderImage sliderImage, HttpPostedFileBase ImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    WebImage img = new WebImage(ImageUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ImageUrl.FileName);
                    string sliderImaging = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1920, 1080);
                    img.Save("~/Images/Slider/" + sliderImaging);
                    sliderImage.ImageUrl = "/Images/Slider/" + sliderImaging;
                }
                sliderImage.LastDateTime = DateTime.Now;
                db.SliderImage.Add(sliderImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SliderId = new SelectList(db.Slider.Where(x => x.IsActiveted == true && x.IsDeleted == false), "Id", "Title", sliderImage.SliderId);
            return View(sliderImage);
        }

        // GET: Panel/SliderImage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SliderImage sliderImage = db.SliderImage.Find(id);
            if (sliderImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.SliderId = new SelectList(db.Slider.Where(x => x.IsActiveted == true && x.IsDeleted == false), "Id", "Title", sliderImage.SliderId);
            return View(sliderImage);
        }

        // POST: Panel/SliderImage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, SliderImage sliderImage, HttpPostedFileBase ImageUrl)
        {
            var SI = db.SliderImage.Find(Id);
            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(SI.ImageUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath(SI.ImageUrl));
                    }
                    WebImage img = new WebImage(ImageUrl.InputStream);
                    FileInfo imginfo = new FileInfo(ImageUrl.FileName);
                    string sliderImaging = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1920, 1080);
                    img.Save("~/Images/Slider/" + sliderImaging);
                    SI.ImageUrl = "/Images/Slider/" + sliderImaging;
                }
                SI.Id = sliderImage.Id;
                SI.Alt = sliderImage.Alt;
                SI.IsActivited = sliderImage.IsActivited;
                SI.LastDateTime = DateTime.Now;
                SI.Name = sliderImage.Name;
                SI.Rank = sliderImage.Rank;
                SI.SliderId = sliderImage.SliderId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SliderId = new SelectList(db.Slider.Where(x => x.IsActiveted == true && x.IsDeleted == false), "Id", "Title", sliderImage.SliderId);
            return View(sliderImage);
        }

        // GET: Panel/SliderImage/Delete/5
        public ActionResult Delete(int id)
        {
            SliderImage sliderImage = db.SliderImage.Include(x => x.Slider).Where(x => x.Id == id).FirstOrDefault();
            if (System.IO.File.Exists(Server.MapPath(sliderImage.ImageUrl)))
            {
                System.IO.File.Delete(Server.MapPath(sliderImage.ImageUrl));
            }
            db.SliderImage.Remove(sliderImage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Panel/SliderImage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SliderImage sliderImage = db.SliderImage.Find(id);
            db.SliderImage.Remove(sliderImage);
            db.SaveChanges();
            return RedirectToAction("Index");
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
