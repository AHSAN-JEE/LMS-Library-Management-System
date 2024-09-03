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
    public class librariansController : Controller
    {
        private LMSEntities db = new LMSEntities();

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Models.librarian model)
        {
            var dt = db.librarians.Where(x => x.Email == model.Email && x.Password==model.Password).SingleOrDefault();
            if (dt != null)
            {
                Session["name"]="set";
                return RedirectToAction("../BOOKs/Index");
            }

            ModelState.AddModelError("","Invalid Email or Password");
            return View();
        }
       



        // GET: librarians
        public ActionResult Index()
        {
            return View(db.librarians.ToList());
        }
        public ActionResult logout()
        {
            Session["name"] = null;
            return RedirectToAction("Home");
        }
        // GET: librarians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            librarian librarian = db.librarians.Find(id);
            if (librarian == null)
            {
                return HttpNotFound();
            }
            return View(librarian);
        }

        // GET: librarians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: librarians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,Email,Password")] librarian librarian)
        {
            if (ModelState.IsValid)
            {
                Session["name"] = "set";
                db.librarians.Add(librarian);
                db.SaveChanges();

                return RedirectToAction("../Home");
            }

            return View(librarian);
        }


        // GET: librarians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            librarian librarian = db.librarians.Find(id);
            if (librarian == null)
            {
                return HttpNotFound();
            }
            return View(librarian);
        }

        // POST: librarians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,Email,Password")] librarian librarian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(librarian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(librarian);
        }

        // GET: librarians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            librarian librarian = db.librarians.Find(id);
            if (librarian == null)
            {
                return HttpNotFound();
            }
            return View(librarian);
        }

        // POST: librarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            librarian librarian = db.librarians.Find(id);
            db.librarians.Remove(librarian);
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
