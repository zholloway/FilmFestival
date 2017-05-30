using FilmFestival.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFestival.Controllers
{
    public class AttendController : Controller
    {
        EmailServices emailServices = new EmailServices();
        BadgeServices badgeServices = new BadgeServices();
        UserServices userServices = new UserServices();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View();
        }

        public ActionResult Success(string badgeSelection, string emailAddress)
        {
            int badgeID = badgeServices.Create(badgeSelection);
            string userID = userServices.Create(emailAddress,badgeID);
            badgeServices.AssignBadgeToUser(badgeID, userID);
            emailServices.SendAccountEmail(badgeID, emailAddress);

            ViewBag.badgeID = badgeID;
            ViewBag.emailAddress = emailAddress;

            return View();
        }
    }
}