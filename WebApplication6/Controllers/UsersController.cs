using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class UsersController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID, UID, HomeTown")] User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Where(dbUser => dbUser.UID.Equals(user.UID) &&
                    dbUser.UserID != user.UserID).Count() > 0)
                {
                    ViewBag.message = "There is already an user with the same ID.";
                    return View("ErrorUID");
                }
                if (user.UID.Length != 10)
                {
                    ViewBag.message = "Incorrect UID!";
                    return View("ErrorUID");
                }
                else
                {
                    try
                    {
                        user.Birthday = Models.User.convertBirthday(user.UID);
                    }
                    catch (Exception e)
                    {
                        ViewBag.message = e.Message;
                        return View("ErrorUID");
                    }
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UID,HomeTown")] User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Where(dbUser => dbUser.UID.Equals(user.UID) &&
                    dbUser.UserID != user.UserID).Count() > 0)
                {
                    ViewBag.message = "There is already an user with the same ID.";
                    return View("ErrorUID");
                }
                if (user.UID.Length != 10)
                {
                    ViewBag.message = "Incorrect UID!";
                    return View("ErrorUID");
                }
                else
                {
                    try
                    {
                        user.Birthday = Models.User.convertBirthday(user.UID);
                    }
                    catch (Exception e)
                    {
                        ViewBag.message = e.Message;
                        return View("ErrorUID");
                    }
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
