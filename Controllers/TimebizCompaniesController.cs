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
    public class TimebizCompaniesController : Controller
    {
        private TimebizjobsEntities db = new TimebizjobsEntities();

        // GET: TimebizCompanies
        public ActionResult Index()
        {
            return View(db.TimebizCompanies.ToList());
        }

        // GET: TimebizCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizCompany timebizCompany = db.TimebizCompanies.Find(id);
            if (timebizCompany == null)
            {
                return HttpNotFound();
            }
            return View(timebizCompany);
        }

        // GET: TimebizCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimebizCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Companyid,Companyname,Website,Mobileno,Phoneno,Email,Password,Address,Imagepath,IsActive")] TimebizCompany timebizCompany)
        {
            if (ModelState.IsValid)
            {
                db.TimebizCompanies.Add(timebizCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timebizCompany);
        }

        // GET: TimebizCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizCompany timebizCompany = db.TimebizCompanies.Find(id);
            if (timebizCompany == null)
            {
                return HttpNotFound();
            }
            return View(timebizCompany);
        }

        // POST: TimebizCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Companyid,Companyname,Website,Mobileno,Phoneno,Email,Password,Address,Imagepath,IsActive")] TimebizCompany timebizCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timebizCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timebizCompany);
        }

        // GET: TimebizCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizCompany timebizCompany = db.TimebizCompanies.Find(id);
            if (timebizCompany == null)
            {
                return HttpNotFound();
            }
            return View(timebizCompany);
        }

        // POST: TimebizCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimebizCompany timebizCompany = db.TimebizCompanies.Find(id);
            db.TimebizCompanies.Remove(timebizCompany);
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
