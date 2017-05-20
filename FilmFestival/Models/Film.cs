using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class Film
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public string PreviewImgPath { get; set; }

        public string InfoImgPath { get; set; }

        public int YearReleased { get; set; } = 2017;

        public string Country { get; set; }

        public int Runtime { get; set; }

        public string BriefSummary { get; set; }

        public string FullDescription { get; set; }

        public ICollection<Showtime> Showtimes { get; set; }
    }
}