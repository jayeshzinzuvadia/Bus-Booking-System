using System;
using System.Collections.Generic;
using System.Text;

namespace BusBookingSystem.Models.Entities
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatStructure { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime DateOfJourney { get; set; }

        // BusRouteId as foreign key
        // One to many relationship between BusRoute and Seat
        public int BusRouteId { get; set; }
        public BusRoute BusRoute { get; set; }
    }
}
