using FilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FilmFestival.Controllers
{
    public class TravelController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Hotels);
        }
    }
}
