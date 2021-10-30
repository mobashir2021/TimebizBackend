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
    public class TimebizCategoriesController : Controller
    {
        private TimebizjobsEntities db = new TimebizjobsEntities();

        // GET: TimebizCategories
        public ActionResult Index()
        {
            return View(db.TimebizCategories.ToList());
        }

        // GET: TimebizCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizCategory timebizCategory = db.TimebizCategories.Find(id);
            if (timebizCategory == null)
            {
                return HttpNotFound();
            }
            return View(timebizCategory);
        }

        // GET: TimebizCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimebizCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Categoryid,Category,Imagepath")] TimebizCategory timebizCategory)
        {
            if (ModelState.IsValid)
            {
                db.TimebizCategories.Add(timebizCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timebizCategory);
        }

        // GET: TimebizCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizCategory timebizCategory = db.TimebizCategories.Find(id);
            if (timebizCategory == null)
            {
                return HttpNotFound();
            }
            return View(timebizCategory);
        }

        // POST: TimebizCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Categoryid,Category,Imagepath")] TimebizCategory timebizCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timebizCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timebizCategory);
        }

        // GET: TimebizCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizCategory timebizCategory = db.TimebizCategories.Find(id);
            if (timebizCategory == null)
            {
                return HttpNotFound();
            }
            return View(timebizCategory);
        }

        // POST: TimebizCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimebizCategory timebizCategory = db.TimebizCategories.Find(id);
            db.TimebizCategories.Remove(timebizCategory);
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
