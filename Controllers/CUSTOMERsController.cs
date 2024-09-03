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
    public class CUSTOMERsController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: CUSTOMERs
        public ActionResult Index()
        {
            var cUSTOMERs = db.CUSTOMERs.Include(c => c.BRANCH);
            return View(cUSTOMERs.ToList());
        }

        // GET: CUSTOMERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // GET: CUSTOMERs/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName");
            return View();
        }

        // POST: CUSTOMERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,CustomerEmail,CustomerAddress,BranchId")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERs.Add(cUSTOMER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName", cUSTOMER.BranchId);
            return View(cUSTOMER);
        }

        // GET: CUSTOMERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName", cUSTOMER.BranchId);
            return View(cUSTOMER);
        }

        // POST: CUSTOMERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,CustomerEmail,CustomerAddress,BranchId")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName", cUSTOMER.BranchId);
            return View(cUSTOMER);
        }

        // GET: CUSTOMERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: CUSTOMERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            db.CUSTOMERs.Remove(cUSTOMER);
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
