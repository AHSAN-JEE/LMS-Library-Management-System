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
    public class STAFFsController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: STAFFs
        public ActionResult Index()
        {
            var sTAFFs = db.STAFFs.Include(s => s.BRANCH);
            return View(sTAFFs.ToList());
        }

        // GET: STAFFs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFs.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // GET: STAFFs/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName");
            return View();
        }

        // POST: STAFFs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,StaffName,StaffEmail,StaffAddress,StaffGender,StaffPhone,BranchId")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.STAFFs.Add(sTAFF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName", sTAFF.BranchId);
            return View(sTAFF);
        }

        // GET: STAFFs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFs.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName", sTAFF.BranchId);
            return View(sTAFF);
        }

        // POST: STAFFs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,StaffName,StaffEmail,StaffAddress,StaffGender,StaffPhone,BranchId")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTAFF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.BRANCHes, "BranchID", "BranchName", sTAFF.BranchId);
            return View(sTAFF);
        }

        // GET: STAFFs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFs.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // POST: STAFFs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STAFF sTAFF = db.STAFFs.Find(id);
            db.STAFFs.Remove(sTAFF);
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
