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
    public class TimebizJobsController : Controller
    {
        private TimebizjobsEntities db = new TimebizjobsEntities();

        // GET: TimebizJobs
        public ActionResult Index()
        {
            return View(db.TimebizJobs.ToList());
        }

        // GET: TimebizJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizJob timebizJob = db.TimebizJobs.Find(id);
            if (timebizJob == null)
            {
                return HttpNotFound();
            }
            return View(timebizJob);
        }

        // GET: TimebizJobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimebizJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Jobid,JobTitle,JobType,CategoryId,DistrictId,Designation,Description,Salary,Companyname,Website,Phoneno,Email,Vacancy,Jobworkday,Jobworktime,Address,Experience,Qualification,Skills,FeaturedImagepath,DateOfInterview")] TimebizJob timebizJob)
        {
            if (ModelState.IsValid)
            {
                db.TimebizJobs.Add(timebizJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timebizJob);
        }

        // GET: TimebizJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizJob timebizJob = db.TimebizJobs.Find(id);
            if (timebizJob == null)
            {
                return HttpNotFound();
            }
            return View(timebizJob);
        }

        // POST: TimebizJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Jobid,JobTitle,JobType,CategoryId,DistrictId,Designation,Description,Salary,Companyname,Website,Phoneno,Email,Vacancy,Jobworkday,Jobworktime,Address,Experience,Qualification,Skills,FeaturedImagepath,DateOfInterview")] TimebizJob timebizJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timebizJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timebizJob);
        }

        // GET: TimebizJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimebizJob timebizJob = db.TimebizJobs.Find(id);
            if (timebizJob == null)
            {
                return HttpNotFound();
            }
            return View(timebizJob);
        }

        // POST: TimebizJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimebizJob timebizJob = db.TimebizJobs.Find(id);
            db.TimebizJobs.Remove(timebizJob);
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
