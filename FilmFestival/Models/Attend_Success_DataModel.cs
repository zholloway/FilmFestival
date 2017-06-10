using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class Attend_Success_DataModel
    {
        public string BadgeLevel { get; set; }

        public string CardHolderEmailAddress { get; set; }

        public Attend_Success_DataModel(double badgePrice, string emailAddress)
        {
            if (badgePrice == 225.00)
            {
                BadgeLevel = "Half Badge";
            }
            else
            {
                BadgeLevel = "Fan Badge";
            }

            CardHolderEmailAddress = emailAddress;
        }
    }
}