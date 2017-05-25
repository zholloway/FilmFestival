using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FilmFestival.Models
{
    public class Seat
    {
        //rows should be from A-E, seats 1-10 for 50 total seats

        public int ID { get; set; }

        public string Row { get; set; }

        public int SeatNumber { get; set; }

        public bool Reserved { get; set; } = false;

        public int ShowtimeID { get; set; }

        [ForeignKey("ShowtimeID")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Showtime Showtime { get; set; }
    }
}