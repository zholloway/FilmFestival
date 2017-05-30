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
            var seatList = DB.Seats
                .Include(i => i.Showtime)
                .Include(i => i.Showtime.Film)
                .Where(w => w.UserID == userID)
                .ToList();
                           
            return seatList;
        }

        public Seat GetIndividualSeat(int seatID)
        {         
            return DB.Seats
                .Include(i => i.Showtime)
                .Include(i => i.ApplicationUser)
                .First(seat => seat.ID == seatID);
        }

        public Seat CancelSeatReservation(int seatID)
        {
            var seat = DB.Seats.First(f => f.ID == seatID);
            seat.Reserved = false;
            seat.UserID = null;
            DB.SaveChanges();

            return seat;
        }
    }
}