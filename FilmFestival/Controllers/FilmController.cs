using FilmFestival.Models;
using FilmFestival.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFestival.Controllers
{
    public class FilmController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        FilmServices filmServices = new FilmServices(db);

        public ActionResult Index()
        {
            return View(filmServices.GetAllFilms());
        }

        public ActionResult Info(int filmID)
        {
            return View(db.Films.First(f => f.ID == filmID));
        }
    }
}