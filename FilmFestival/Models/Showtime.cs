using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public ICollection<Seat> Seats { get; set; }

        public int FilmID { get; set; }

        [ForeignKey("FilmID")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Film Film { get; set; }

        public int AvailableSeats()
        {
            var rv = 0;

            foreach (var seat in Seats)
            {
                if(seat.Reserved == false)
                {
                    rv++;
                }
            }

            return rv;
        }

        public int ReservedSeats()
        {
            return this.Seats.Count - this.AvailableSeats();
        }

        public Showtime()
        {
            var seatList = new List<Seat>();

            for (int i = 0; i < 50; i++)
            {
                if(i < 10)
                {
                    var seat = new Seat { Row = "A", SeatNumber = (i + 1), ShowtimeID = this.ID};
                    seatList.Add(seat);
                }
                else if (i >= 10 && i < 20)
                {
                    var seat = new Seat { Row = "B", SeatNumber = (i - 9), ShowtimeID = this.ID };
                    seatList.Add(seat);
                }
                else if (i >= 20 && i < 30)
                {
                    var seat = new Seat { Row = "C", SeatNumber = (i - 19), ShowtimeID = this.ID };
                    seatList.Add(seat);
                }
                else if (i >= 30 && i < 40)
                {
                    var seat = new Seat { Row = "D", SeatNumber = (i - 29), ShowtimeID = this.ID };
                    seatList.Add(seat);
                }
                else
                {
                    var seat = new Seat { Row = "E", SeatNumber = (i - 39), ShowtimeID = this.ID };
                    seatList.Add(seat);
                }
            }

            Seats = seatList;
        }
    }
}