using FilmFestival.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace FilmFestival.Services
{
    public class UserServices
    {
        public ApplicationDbContext DB { get; } = new ApplicationDbContext();

        public string Create(string emailAddress, int badgeID)
        {
            var pwHash = Crypto.HashPassword(badgeID.ToString());

            var newUser = new ApplicationUser {
                Email = emailAddress,
                UserName = emailAddress,
                PasswordHash = pwHash,
                BadgeID = badgeID,
                SecurityStamp = new Guid().ToString()              
            };

            DB.Users.Add(newUser);
            DB.SaveChanges();

            //add new ApplicationUser to 'user' role
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(DB));
            userManager.AddToRole(newUser.Id, "user");

            return newUser.Id;
        }
    }
}