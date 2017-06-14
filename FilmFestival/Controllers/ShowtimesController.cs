using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmFestival.Models;

namespace FilmFestival.Controllers
{
    public class ShowtimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Showtimes
        public ActionResult Index()
        {
            var showtimes = db.Showtimes.Include(s => s.Film).OrderByDescending(o => o.DateAndTime);
            return View(showtimes.ToList());
        }

        // GET: Showtimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Showtime showtime = db.Showtimes.Include(i => i.Film).First(f => f.ID == id);

            if (showtime == null)
            {
                return HttpNotFound();
            }

            List<string> users = db.Seats
                .Include(i => i.ApplicationUser)
                .Where(w => w.ShowtimeID == id)
                .OrderBy(o => o.ApplicationUser.UserName)
                .Select(s => s.ApplicationUser.UserName)
                .ToList();

            var vbList = new List<string>();

            foreach (var user in users)
            {
                if (user != null)
                {
                    vbList.Add(user);
                }
            }

            ViewBag.UserList = vbList;

            return View(showtime);
        }

        // GET: Showtimes/Create
        public ActionResult Create()
        {
            ViewBag.FilmID = new SelectList(db.Films, "ID", "Title");
            return View();
        }

        // POST: Showtimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateAndTime,Theatre,FilmID")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                db.Showtimes.Add(showtime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmID = new SelectList(db.Films, "ID", "Title", showtime.FilmID);
            return View(showtime);
        }

        // GET: Showtimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = db.Showtimes.Find(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmID = new SelectList(db.Films, "ID", "Title", showtime.FilmID);
            return View(showtime);
        }

        // POST: Showtimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Time,Theatre,FilmID")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showtime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmID = new SelectList(db.Films, "ID", "Title", showtime.FilmID);
            return View(showtime);
        }

        // GET: Showtimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = db.Showtimes.Include(i => i.Film).First(f => f.ID == id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            return View(showtime);
        }

        // POST: Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Showtime showtime = db.Showtimes.Find(id);
            db.Showtimes.Remove(showtime);
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
