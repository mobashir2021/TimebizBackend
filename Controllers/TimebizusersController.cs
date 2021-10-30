using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobclubBackend.Models;

namespace JobclubBackend.Controllers
{
    public class TimebizusersController : Controller
    {
        private TimebizjobsEntities db = new TimebizjobsEntities();

        // GET: Timebizusers
        public ActionResult Index()
        {
            return View(db.Timebizusers.ToList());
        }

        // GET: Timebizusers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timebizuser timebizuser = db.Timebizusers.Find(id);
            if (timebizuser == null)
            {
                return HttpNotFound();
            }
            return View(timebizuser);
        }

        // GET: Timebizusers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Timebizusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Userid,Username,Password,Roles,LastLogin,CreatedOn,IsActive,Name,Mobileno,District,Address,CurrentCompany,Experience,Skills,Gender,DOB,UserImagePath,ResumePath")] Timebizuser timebizuser)
        {
            if (ModelState.IsValid)
            {
                db.Timebizusers.Add(timebizuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timebizuser);
        }

        // GET: Timebizusers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timebizuser timebizuser = db.Timebizusers.Find(id);
            if (timebizuser == null)
            {
                return HttpNotFound();
            }
            return View(timebizuser);
        }

        // POST: Timebizusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Userid,Username,Password,Roles,LastLogin,CreatedOn,IsActive,Name,Mobileno,District,Address,CurrentCompany,Experience,Skills,Gender,DOB,UserImagePath,ResumePath")] Timebizuser timebizuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timebizuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timebizuser);
        }

        // GET: Timebizusers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timebizuser timebizuser = db.Timebizusers.Find(id);
            if (timebizuser == null)
            {
                return HttpNotFound();
            }
            return View(timebizuser);
        }

        // POST: Timebizusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timebizuser timebizuser = db.Timebizusers.Find(id);
            db.Timebizusers.Remove(timebizuser);
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
