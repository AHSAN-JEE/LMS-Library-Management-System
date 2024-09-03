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
    public class RETURNBOOKsController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: RETURNBOOKs
        public ActionResult Index()
        {
            var rETURNBOOKs = db.RETURNBOOKs.Include(r => r.BOOK).Include(r => r.CUSTOMER).Include(r => r.STAFF);
            return View(rETURNBOOKs.ToList());
        }

        // GET: RETURNBOOKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RETURNBOOK rETURNBOOK = db.RETURNBOOKs.Find(id);
            if (rETURNBOOK == null)
            {
                return HttpNotFound();
            }
            return View(rETURNBOOK);
        }

        // GET: RETURNBOOKs/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName");
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName");
            ViewBag.StaffID = new SelectList(db.STAFFs, "StaffID", "StaffName");
            return View();
        }

        // POST: RETURNBOOKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReturnID,IssueDate,ExpiryDate,BookID,StaffID,CustomerId")] RETURNBOOK rETURNBOOK)
        {
            if (ModelState.IsValid)
            {
                db.RETURNBOOKs.Add(rETURNBOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName", rETURNBOOK.BookID);
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName", rETURNBOOK.CustomerId);
            ViewBag.StaffID = new SelectList(db.STAFFs, "StaffID", "StaffName", rETURNBOOK.StaffID);
            return View(rETURNBOOK);
        }

        // GET: RETURNBOOKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RETURNBOOK rETURNBOOK = db.RETURNBOOKs.Find(id);
            if (rETURNBOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName", rETURNBOOK.BookID);
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName", rETURNBOOK.CustomerId);
            ViewBag.StaffID = new SelectList(db.STAFFs, "StaffID", "StaffName", rETURNBOOK.StaffID);
            return View(rETURNBOOK);
        }

        // POST: RETURNBOOKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReturnID,IssueDate,ExpiryDate,BookID,StaffID,CustomerId")] RETURNBOOK rETURNBOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rETURNBOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName", rETURNBOOK.BookID);
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName", rETURNBOOK.CustomerId);
            ViewBag.StaffID = new SelectList(db.STAFFs, "StaffID", "StaffName", rETURNBOOK.StaffID);
            return View(rETURNBOOK);
        }

        // GET: RETURNBOOKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RETURNBOOK rETURNBOOK = db.RETURNBOOKs.Find(id);
            if (rETURNBOOK == null)
            {
                return HttpNotFound();
            }
            return View(rETURNBOOK);
        }

        // POST: RETURNBOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RETURNBOOK rETURNBOOK = db.RETURNBOOKs.Find(id);
            db.RETURNBOOKs.Remove(rETURNBOOK);
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
