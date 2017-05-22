using FilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFestival.Controllers
{
    public class NewsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.NewsStories);
        }

        public ActionResult Story(int storyID)
        {
            return View(db.NewsStories.First(f => f.ID == storyID));
        }
    }
}