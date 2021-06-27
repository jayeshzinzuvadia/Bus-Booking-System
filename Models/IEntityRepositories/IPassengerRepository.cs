using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface IPassengerRepository
    {
        Passenger Add(Passenger passenger);
        Passenger Update(Passenger passengerChanges);
        bool Delete(string passengerUserId);
        Passenger GetPassenger(string passengerUserId);
        IEnumerable<Passenger> GetPassengerList();
    }
}
