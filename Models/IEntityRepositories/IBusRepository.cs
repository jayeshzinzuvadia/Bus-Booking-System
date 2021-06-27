using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface IBusRepository
    {
        Bus Add(Bus bus);
        Bus Update(Bus busChanges);
        bool Delete(int busId);
        Bus GetBus(int busId);
        Bus GetBusFromBusOperatorId(string busOperatorId);
        IEnumerable<BusOperator> GetAvailableBusOperators();
        IEnumerable<Bus> GetAllBuses();
        IEnumerable<Bus> FilterBusByBusType(List<Bus> buses, BusTypes busType);
        IEnumerable<Bus> FilterBusByBusTime(List<Bus> buses, string busTime);
        IEnumerable<Bus> FilterBusByRatings(List<Bus> buses);
    }
}
