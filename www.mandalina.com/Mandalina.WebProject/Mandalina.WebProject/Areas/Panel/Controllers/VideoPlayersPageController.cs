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
    public class VideoPlayersPageController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/VideoPlayerPage
        public ActionResult Index()
        {
            var videoPlayer = db.VideoPlayer.Include(v => v.Language);
            return View(videoPlayer.ToList());
        }

        // GET: Panel/VideoPlayerPage/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Panel/VideoPlayerPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(VideoPlayer videoPlayer, HttpPostedFileBase VideoUrl)
        {
            if (ModelState.IsValid)
            {
                if (VideoUrl != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + VideoUrl.FileName);
                    var url = Path.Combine(Server.MapPath("~/Images/VideoPlayer/" + photoName));
                    VideoUrl.SaveAs(url);
                    videoPlayer.VideUrl = photoName;
                    videoPlayer.IsDeleted = false;
                    videoPlayer.LastDateTime = DateTime.Now;
                    db.VideoPlayer.Add(videoPlayer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", videoPlayer.LanguageId);
            return View(videoPlayer);
        }

        // GET: Panel/VideoPlayerPage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoPlayer videoPlayer = db.VideoPlayer.Find(id);
            if (videoPlayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", videoPlayer.LanguageId);
            return View(videoPlayer);
        }

        // POST: Panel/VideoPlayerPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int Id, VideoPlayer videoPlayer, HttpPostedFileBase VideoUrl)
        {
            var VP = db.VideoPlayer.Find(Id);
            if (ModelState.IsValid)
            {
                if (VideoUrl != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Images/VideoPlayer/" + VP.VideUrl)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/VideoPlayer/" + VP.VideUrl));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + VideoUrl.FileName);
                    var url = Path.Combine(Server.MapPath("~/Images/VideoPlayer/" + photoName));
                    VideoUrl.SaveAs(url);
                    VP.Id = videoPlayer.Id;
                    VP.Alt = videoPlayer.Alt;
                    VP.Content = videoPlayer.Content;
                    VP.IsActiveted = videoPlayer.IsActiveted;
                    VP.IsDeleted = videoPlayer.IsDeleted;
                    VP.LanguageId = videoPlayer.LanguageId;
                    VP.LastDateTime = DateTime.Now;
                    VP.Rank = videoPlayer.Rank;
                    VP.Title = videoPlayer.Title;
                    VP.VideUrl = photoName;
                    VP.ProductUrl = videoPlayer.ProductUrl;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", videoPlayer.LanguageId);
            return View(videoPlayer);
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
