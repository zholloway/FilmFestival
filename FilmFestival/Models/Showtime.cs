using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class Showtime
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string Theatre { get; set; }

        public int AvailableSeats { get; set; } = 50;

        public int ReservedSeats { get; set; } = 0;

        public int FilmID { get; set; }
        public Film Film { get; set; }

    }
}