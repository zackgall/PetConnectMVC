using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetConnect.DAL;
using PetConnect.Models;

namespace PetConnect.Controllers
{
    public class ChirpsController : Controller
    {
        private PetConnectDBContext db = new PetConnectDBContext();

        // GET: Chirps
        public ActionResult Index()
        {
            var chirps = db.Chirps.Include(c => c.User);
            return View(chirps.ToList());
        }

        // GET: Chirps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chirps chirps = db.Chirps.Find(id);
            if (chirps == null)
            {
                return HttpNotFound();
            }
            return View(chirps);
        }

        // GET: Chirps/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Chirps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,Text,CreateDateTime,Liked")] Chirps chirps)
        {
            if (ModelState.IsValid)
            {
                db.Chirps.Add(chirps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", chirps.UserId);
            return View(chirps);
        }

        // GET: Chirps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chirps chirps = db.Chirps.Find(id);
            if (chirps == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", chirps.UserId);
            return View(chirps);
        }

        // POST: Chirps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Text,CreateDateTime,Liked")] Chirps chirps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chirps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", chirps.UserId);
            return View(chirps);
        }

        // GET: Chirps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chirps chirps = db.Chirps.Find(id);
            if (chirps == null)
            {
                return HttpNotFound();
            }
            return View(chirps);
        }

        // POST: Chirps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chirps chirps = db.Chirps.Find(id);
            db.Chirps.Remove(chirps);
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
