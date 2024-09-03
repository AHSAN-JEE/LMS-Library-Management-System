using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMS_SYSTEM.Models;

namespace LMS_SYSTEM.Controllers
{
    public class BOOKSCATEGORiesController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: BOOKSCATEGORies
        public ActionResult Index()
        {
            return View(db.BOOKSCATEGORies.ToList());
        }

        // GET: BOOKSCATEGORies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKSCATEGORY bOOKSCATEGORY = db.BOOKSCATEGORies.Find(id);
            if (bOOKSCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(bOOKSCATEGORY);
        }

        // GET: BOOKSCATEGORies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BOOKSCATEGORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] BOOKSCATEGORY bOOKSCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.BOOKSCATEGORies.Add(bOOKSCATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bOOKSCATEGORY);
        }

        // GET: BOOKSCATEGORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKSCATEGORY bOOKSCATEGORY = db.BOOKSCATEGORies.Find(id);
            if (bOOKSCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(bOOKSCATEGORY);
        }

        // POST: BOOKSCATEGORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] BOOKSCATEGORY bOOKSCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOKSCATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOOKSCATEGORY);
        }

        // GET: BOOKSCATEGORies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKSCATEGORY bOOKSCATEGORY = db.BOOKSCATEGORies.Find(id);
            if (bOOKSCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(bOOKSCATEGORY);
        }

        // POST: BOOKSCATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOKSCATEGORY bOOKSCATEGORY = db.BOOKSCATEGORies.Find(id);
            db.BOOKSCATEGORies.Remove(bOOKSCATEGORY);
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
