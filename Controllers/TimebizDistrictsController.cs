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
    public class TimebizDistrictsController : Controller
    {
        private TimebizjobsEntities db = new TimebizjobsEntities();

        // GET: TimebizDistricts
        public ActionResult Index()
        {
            return View(db.TimebizDistricts.ToList());
        }

        // GET: TimebizDistricts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizDistrict timebizDistrict = db.TimebizDistricts.Find(id);
            if (timebizDistrict == null)
            {
                return HttpNotFound();
            }
            return View(timebizDistrict);
        }

        // GET: TimebizDistricts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimebizDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Districtid,District")] TimebizDistrict timebizDistrict)
        {
            if (ModelState.IsValid)
            {
                db.TimebizDistricts.Add(timebizDistrict);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timebizDistrict);
        }

        // GET: TimebizDistricts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizDistrict timebizDistrict = db.TimebizDistricts.Find(id);
            if (timebizDistrict == null)
            {
                return HttpNotFound();
            }
            return View(timebizDistrict);
        }

        // POST: TimebizDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Districtid,District")] TimebizDistrict timebizDistrict)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timebizDistrict).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timebizDistrict);
        }

        // GET: TimebizDistricts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizDistrict timebizDistrict = db.TimebizDistricts.Find(id);
            if (timebizDistrict == null)
            {
                return HttpNotFound();
            }
            return View(timebizDistrict);
        }

        // POST: TimebizDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimebizDistrict timebizDistrict = db.TimebizDistricts.Find(id);
            db.TimebizDistricts.Remove(timebizDistrict);
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
