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
    public class UserMembersController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Panel/UserMembers
        public ActionResult Index()
        {
            return View(db.Member.ToList());
        }

        // GET: Panel/UserMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Panel/UserMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member,string RePassword)
        {
            var UM = db.Member.Where(x => x.UserName.ToLower().ToUpper() == member.UserName.ToLower().ToUpper()).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (UM != null)
                {
                    ViewBag.ErrorMessage = "Lütfen aynı kullanıcı adında aynı kişiyi eklemeyiniz";
                    return View(member);
                }
                else
                {
                    if (member.Password != RePassword)
                    {
                        ViewBag.ErrorMessage = "Girmiş Olduğunuz Şifreler Uyuşmuyor";
                        return View(member);
                    }
                    else
                    {
                        member.IsDeleted = false;
                        member.LastDateTime = DateTime.Now;
                        db.Member.Add(member);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(member);
        }

        // GET: Panel/UserMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Member.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Panel/UserMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Member member,string RePassword,string RePassword2)
        {
            var M = db.Member.Find(Id);
            var UM = db.Member.Where(x => x.UserName.ToLower().ToUpper() == member.UserName.ToLower().ToUpper() && x.Id!=Id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (UM != null)
                {
                    ViewBag.Mesaj = "Sistemde Aynı Kullanıcı Adında Bir Kullanıcı Olduğu İçin Üzerine Yazma İşlemi Yapamıyoruz";
                    return View(member);
                }
                else
                {
                    if (RePassword != "")
                    {
                        if (RePassword == RePassword2)
                        {
                            M.Id = member.Id;
                            M.IsDeleted = false;
                            M.LastDateTime = DateTime.Now;
                            M.Name = member.Name;
                            M.Password = RePassword;
                            M.RoleId = member.RoleId;
                            M.Surname = member.Surname;
                            M.UserName = member.UserName;
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Şifre Uyuşmuyor Tekrar Deneyiniz";
                            return View(member);
                        }
                    }
                    else
                    {
                        M.Id = member.Id;
                        M.IsDeleted = false;
                        M.LastDateTime = DateTime.Now;
                        M.Name = member.Name;
                        M.Password = member.Password;
                        M.RoleId = member.RoleId;
                        M.Surname = member.Surname;
                        M.UserName = member.UserName;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }

            }
            return View(member);
        }

        // GET: Panel/UserMembers/Delete/5
        public ActionResult Delete(int id)
        {
            Member member = db.Member.Find(id);
            if (ModelState.IsValid)
            {
                db.Member.Remove(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
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
