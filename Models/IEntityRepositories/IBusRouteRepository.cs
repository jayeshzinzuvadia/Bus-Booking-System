using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface IBusRouteRepository
    {
        BusRoute AddBusRoute(BusRoute busRoute);
        BusRoute UpdateBusRoute(BusRoute busRouteChanges);
        bool DeleteBusRoute(int busRouteId);
        BusRoute GetBusRoute(int busRouteId);
        List<BusRoute> SearchBuses(string source, string destination);
        List<BusRoute> GetAllBusRoutesByBusId(int busId);

        // For seat cancellation 
        BusRoute GetBusRouteFromBusName(string busName, string source, string destination);
    }
}
