﻿using FilmFestival.Models;
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
        StripeServices stripeServices = new StripeServices();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy()
        {
            return View(new StripeCharge());
        }

        [HttpPost]
        public ActionResult Buy(StripeCharge charge)
        {
            if (!ModelState.IsValid)
            {
                return View(charge);
            }

            //Process payment
            var chargeID = stripeServices.ProcessPayment(charge);

            //Save the Stripe's transaction ID to the charge and add to database
            charge.StripeTransactionID = chargeID.ToString();
            stripeServices.AddStripeCharge(charge);

            //Pass required data to Success method
            var model = new Attend_Success_DataModel(charge.Amount, charge.CardHolderEmail);

            return RedirectToAction("Success", model);
        }

        public ActionResult Success(string BadgeLevel, string CardHolderEmailAddress)
        {
            int badgeID = badgeServices.Create(BadgeLevel);
            string userID = userServices.Create(CardHolderEmailAddress,badgeID);
            badgeServices.AssignBadgeToUser(badgeID, userID);
            emailServices.SendAccountEmail(badgeID, CardHolderEmailAddress);

            ViewBag.badgeID = badgeID;
            ViewBag.emailAddress = CardHolderEmailAddress;

            return View();
        }
    }
}