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
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        NewsServices newsServices = new NewsServices();

        public ActionResult Index(int pageIndex = 1, int pageSize = 10)
        {
            ViewBag.PageIndex = pageIndex;
            return View(newsServices.GetAllNews(pageIndex, pageSize));
        }

        public ActionResult Story(int storyID)
        {
            return View(newsServices.GetIndividualStory(storyID));
        }

        public ActionResult NewsList()
        {
            return View(db.NewsStories.OrderByDescending(o => o.Date).ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsStory newsStory = db.NewsStories.Find(id);
            if (newsStory == null)
            {
                return HttpNotFound();
            }
            return View(newsStory);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,SubTitle,Author,Date,StoryImgPath,StoryBody")] NewsStory newsStory)
        {
            if (ModelState.IsValid)
            {
                db.NewsStories.Add(newsStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsStory);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsStory newsStory = db.NewsStories.Find(id);
            if (newsStory == null)
            {
                return HttpNotFound();
            }
            return View(newsStory);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,SubTitle,Author,Date,StoryImgPath,StoryBody")] NewsStory newsStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsStory);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsStory newsStory = db.NewsStories.Find(id);
            if (newsStory == null)
            {
                return HttpNotFound();
            }
            return View(newsStory);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsStory newsStory = db.NewsStories.Find(id);
            db.NewsStories.Remove(newsStory);
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
