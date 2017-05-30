using FilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Services
{
    public class BadgeServices
    {
        public ApplicationDbContext DB { get; } = new ApplicationDbContext();

        public int Create(string badgeLevel)
        {
            var newBadge = new Badge { BadgeLevel = badgeLevel };
            DB.Badges.Add(newBadge);
            DB.SaveChanges();

            return newBadge.ID;
        }

        public void AssignBadgeToUser(int badgeID, string userID)
        {
            var badge = DB.Badges.First(f => f.ID == badgeID);
            badge.UserID = userID;
            DB.SaveChanges();
        }
    }
}