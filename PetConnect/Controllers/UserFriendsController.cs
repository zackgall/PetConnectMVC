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
    public class UserFriendsController : Controller
    {
        private PetConnectDBContext db = new PetConnectDBContext();

        // GET: UserFriends
        public ActionResult Index()
        {
            var userFriends = db.UserFriends.Include(u => u.User);
            return View(userFriends.ToList());
        }

        // GET: UserFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFriends userFriends = db.UserFriends.Find(id);
            if (userFriends == null)
            {
                return HttpNotFound();
            }
            return View(userFriends);
        }

        // GET: UserFriends/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: UserFriends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,FriendId")] UserFriends userFriends)
        {
            if (ModelState.IsValid)
            {
                db.UserFriends.Add(userFriends);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", userFriends.UserId);
            return View(userFriends);
        }

        // GET: UserFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFriends userFriends = db.UserFriends.Find(id);
            if (userFriends == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", userFriends.UserId);
            return View(userFriends);
        }

        // POST: UserFriends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,FriendId")] UserFriends userFriends)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFriends).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserName", userFriends.UserId);
            return View(userFriends);
        }

        // GET: UserFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFriends userFriends = db.UserFriends.Find(id);
            if (userFriends == null)
            {
                return HttpNotFound();
            }
            return View(userFriends);
        }

        // POST: UserFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserFriends userFriends = db.UserFriends.Find(id);
            db.UserFriends.Remove(userFriends);
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
