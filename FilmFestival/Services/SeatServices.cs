using FilmFestival.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmFestival.Services
{
    public class SeatServices
    {
        public ApplicationDbContext DB { get; } = new ApplicationDbContext();

        public void ReserveSeat(int seatID, string userID)
        {
            var seat = DB.Seats.First(f => f.ID == seatID);
            seat.Reserved = true;
            seat.UserID = userID;
            DB.SaveChanges();
        }

        public List<Seat> GetSeatsForUser(string userID)
        {
            var seatList = DB.Seats.Where(w => w.UserID == userID).ToList();
            return seatList;
        }
    }
}