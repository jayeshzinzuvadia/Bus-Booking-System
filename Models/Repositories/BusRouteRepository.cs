using BusBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BusBookingSystem.Models.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusBookingSystem.Models.Repositories
{
    public class BusRouteRepository : IBusRouteRepository
    {
        private readonly AppDbContext context;
        public BusRouteRepository(AppDbContext context)
        {
            this.context = context;
        }

        public BusRoute AddBusRoute(BusRoute busRoute)
        {
            context.BusRoute.Add(busRoute);
            context.SaveChanges();
            return busRoute;
        }

        public bool DeleteBusRoute(int busRouteId)
        {
            BusRoute busRoute = GetBusRoute(busRouteId);
            if (busRoute != null)
            {
                context.BusRoute.Remove(busRoute);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<BusRoute> GetAllBusRoutesByBusId(int busId)
        {
            return context.BusRoute.OrderBy(br => br.RouteOrder)
                                .ToList()
                                .FindAll(bus => bus.BusId == busId);
        }

        public BusRoute GetBusRoute(int busRouteId)
        {
            return context.BusRoute.FirstOrDefault(id => id.BusRouteId == busRouteId);
        }

        public BusRoute GetBusRouteFromBusName(string busName, string source, string destination)
        {
            Bus busObj = context.Bus.FirstOrDefault(b => b.BusName == busName);
            if (busObj != null)
            {
                BusRoute busRouteObj = SearchBuses(source, destination).Find(b => b.BusId == busObj.BusId);
                return busRouteObj;
            }
            return null;
        }

        public List<BusRoute> SearchBuses(string source, string destination)
        {
            return context.BusRoute.OrderBy(br => br.TicketPrice)
                 .Where(br => br.Source == source && br.Destination == destination)
                 .ToList();
        }

        public BusRoute UpdateBusRoute(BusRoute busRouteChanges)
        {
            var busRoute = context.BusRoute.Attach(busRouteChanges);
            busRoute.State = EntityState.Modified;
            context.SaveChanges();
            return busRouteChanges;
        }
    }
}
