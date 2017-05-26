using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models.View_Models
{
    public class FilmInfo
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string InfoImgPath { get; set; }

        public int YearReleased { get; set; }

        public string Country { get; set; }

        public int Runtime { get; set; }

        public string BriefSummary { get; set; }

        public string FullDescription { get; set; }

        public List<Showtime> Showtimes { get; set; }
    }
}