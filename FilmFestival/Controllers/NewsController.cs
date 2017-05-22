using FilmFestival.Models;
using FilmFestival.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFestival.Controllers
{
    public class NewsController : Controller
    {
        static ApplicationDbContext db = new ApplicationDbContext();

        NewsServices newsServices = new NewsServices(db);

        public ActionResult Index()
        {
            return View(newsServices.GetAllNews());
        }

        public ActionResult Story(int storyID)
        {
            return View(newsServices.GetIndividualStory(storyID));
        }
    }
}