using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFestival.Controllers
{
    public class FilmController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }
    }
}