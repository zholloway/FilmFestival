using FilmFestival.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFestival.Controllers
{
    public class SeatsController : Controller
    {
        SeatServices seatServices = new SeatServices();

        public ActionResult Details(int seatID)
        {
            return View(seatServices.GetIndividualSeat(seatID));
        }

        public ActionResult CancelSeatReservation(int seatID)
        {
            var seat = seatServices.CancelSeatReservation(seatID);
            return RedirectToAction("UserDashboard", "Account");
        }
    }
}