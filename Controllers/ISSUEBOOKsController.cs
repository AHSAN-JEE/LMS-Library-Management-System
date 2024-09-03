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
    public class ISSUEBOOKsController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: ISSUEBOOKs
        public ActionResult Index()
        {
            var iSSUEBOOKs = db.ISSUEBOOKs.Include(i => i.BOOK).Include(i => i.CUSTOMER);
            return View(iSSUEBOOKs.ToList());
        }

        // GET: ISSUEBOOKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISSUEBOOK iSSUEBOOK = db.ISSUEBOOKs.Find(id);
            if (iSSUEBOOK == null)
            {
                return HttpNotFound();
            }
            return View(iSSUEBOOK);
        }

        // GET: ISSUEBOOKs/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName");
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName");
            return View();
        }

        // POST: ISSUEBOOKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IssueID,IssueDate,ExpiryDate,BookID,CustomerId")] ISSUEBOOK iSSUEBOOK)
        {
            if (ModelState.IsValid)
            {
                db.ISSUEBOOKs.Add(iSSUEBOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName", iSSUEBOOK.BookID);
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName", iSSUEBOOK.CustomerId);
            return View(iSSUEBOOK);
        }

        // GET: ISSUEBOOKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISSUEBOOK iSSUEBOOK = db.ISSUEBOOKs.Find(id);
            if (iSSUEBOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName", iSSUEBOOK.BookID);
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName", iSSUEBOOK.CustomerId);
            return View(iSSUEBOOK);
        }

        // POST: ISSUEBOOKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IssueID,IssueDate,ExpiryDate,BookID,CustomerId")] ISSUEBOOK iSSUEBOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iSSUEBOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.BOOKS, "BookID", "BookName", iSSUEBOOK.BookID);
            ViewBag.CustomerId = new SelectList(db.CUSTOMERs, "CustomerID", "CustomerName", iSSUEBOOK.CustomerId);
            return View(iSSUEBOOK);
        }

        // GET: ISSUEBOOKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ISSUEBOOK iSSUEBOOK = db.ISSUEBOOKs.Find(id);
            if (iSSUEBOOK == null)
            {
                return HttpNotFound();
            }
            return View(iSSUEBOOK);
        }

        // POST: ISSUEBOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ISSUEBOOK iSSUEBOOK = db.ISSUEBOOKs.Find(id);
            db.ISSUEBOOKs.Remove(iSSUEBOOK);
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
