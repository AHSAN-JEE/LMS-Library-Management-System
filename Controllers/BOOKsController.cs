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
    public class BOOKsController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: BOOKs
        public ActionResult Index()
        {
            var bOOKS = db.BOOKS.Include(b => b.BOOKSCATEGORY);
            return View(bOOKS.ToList());
        }

        // GET: BOOKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKS.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // GET: BOOKs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.BOOKSCATEGORies, "CategoryID", "CategoryName");
            return View();
        }

        // POST: BOOKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,BookName,BookAuthor,CategoryID")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.BOOKS.Add(bOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.BOOKSCATEGORies, "CategoryID", "CategoryName", bOOK.CategoryID);
            return View(bOOK);
        }

        // GET: BOOKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKS.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.BOOKSCATEGORies, "CategoryID", "CategoryName", bOOK.CategoryID);
            return View(bOOK);
        }

        // POST: BOOKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,BookName,BookAuthor,CategoryID")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.BOOKSCATEGORies, "CategoryID", "CategoryName", bOOK.CategoryID);
            return View(bOOK);
        }

        // GET: BOOKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKS.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: BOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK bOOK = db.BOOKS.Find(id);
            db.BOOKS.Remove(bOOK);
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
