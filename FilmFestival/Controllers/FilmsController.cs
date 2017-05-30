using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmFestival.Models;
using FilmFestival.Services;

namespace FilmFestival.Controllers
{
    public class FilmsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        FilmServices filmServices = new FilmServices();

        // GET: Films
        public ActionResult Index(int pageIndex = 1, int pageSize = 12, string sortBy = "Title")
        {
            ViewBag.PageIndex = pageIndex;
            return View(filmServices.GetAllFilms(pageIndex, pageSize, sortBy));
        }

        [HttpGet]
        public ActionResult Info(int filmID)
        {
            var filmInfo = filmServices.GetIndividualFilm(filmID);

            ViewBag.areShowtimes21 = false;
            ViewBag.areShowtimes22 = false;
            ViewBag.areShowtimes23 = false;
            ViewBag.areShowtimes24 = false;
            ViewBag.areShowtimes25 = false;
            ViewBag.areShowtimes26 = false;
            ViewBag.areShowtimes27 = false;
            ViewBag.areShowtimes28 = false;

            foreach (var showtime in filmInfo.Showtimes)
            {
                if (showtime.Date.ToShortDateString() == "9/21/2017")
                {
                    ViewBag.areShowtimes21 = true;
                }
                if (showtime.Date.ToShortDateString() == "9/22/2017")
                {
                    ViewBag.areShowtimes22 = true;
                }
                if (showtime.Date.ToShortDateString() == "9/23/2017")
                {
                    ViewBag.areShowtimes23 = true;
                }
                if (showtime.Date.ToShortDateString() == "9/24/2017")
                {
                    ViewBag.areShowtimes24 = true;
                }
                if (showtime.Date.ToShortDateString() == "9/25/2017")
                {
                    ViewBag.areShowtimes25 = true;
                }
                if (showtime.Date.ToShortDateString() == "9/26/2017")
                {
                    ViewBag.areShowtimes26 = true;
                }
                if (showtime.Date.ToShortDateString() == "9/27/2017")
                {
                    ViewBag.areShowtimes27 = true;
                }
                if (showtime.Date.ToShortDateString() == "9/28/2017")
                {
                    ViewBag.areShowtimes28 = true;
                }
            }

            return View(filmInfo);
        }

        public ActionResult SeatReservationForm(int showtimeID)
        {
            List<Seat> seats = db.Seats.Where(w => w.ShowtimeID == showtimeID).ToList();
            return PartialView("_seatReservationForm", seats);
        }

        public ActionResult FilmList()
        {
            var filmList = db.Films.Include(i => i.Showtimes).ToList();
            return View(filmList);
        }

        // GET: Films/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Include(i => i.Showtimes).First(f => f.ID == id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Director,PreviewImgPath,InfoImgPath,YearReleased,Country,Runtime,BriefSummary,FullDescription")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Films.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(film);
        }

        // GET: Films/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Director,PreviewImgPath,InfoImgPath,YearReleased,Country,Runtime,BriefSummary,FullDescription")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.Films.Find(id);
            db.Films.Remove(film);
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
