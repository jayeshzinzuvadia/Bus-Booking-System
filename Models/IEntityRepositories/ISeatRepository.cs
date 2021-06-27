using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface ISeatRepository
    {
        Seat Add(Seat seat);
        Seat Update(Seat seatChanges);
        bool Delete(int seatId);
        Seat GetSeatFromSeatId(int seatId);
        Seat GetSeatDetails(int busRouteId, DateTime dateOfBooking);
        IEnumerable<int> GetBookedSeatList(int busRouteId, DateTime dateOfBooking);
        void DeleteAllSeatsFromBusRouteId(int busRouteId);
    }
}
