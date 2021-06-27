using BusBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BusBookingSystem.Models.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusBookingSystem.Models.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly AppDbContext context;
        public BusRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Bus Add(Bus bus)
        {
            context.Bus.Add(bus);
            context.SaveChanges();
            return bus;
        }

        public IEnumerable<Bus> FilterBusByBusType(List<Bus> buses, BusTypes busType)
        {
            return buses.FindAll(bus => bus.BusType == busType);
        }

        public bool Delete(int busId)
        {
            Bus bus = GetBus(busId);
            if (bus != null)
            {
                context.Bus.Remove(bus);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Bus> GetAllBuses()
        {
            return context.Bus;
        }

        public IEnumerable<BusOperator> GetAvailableBusOperators()
        {
            List<BusOperator> freeBusOperators = new List<BusOperator>();
            List<BusOperator> allBusOperators = context.BusOperator.ToList();
            foreach (BusOperator busOperator in allBusOperators)
            {
                Bus bus = GetBusFromBusOperatorId(busOperator.Id);
                if (bus == null)
                {
                    freeBusOperators.Add(busOperator);
                }
            }
            return freeBusOperators;
        }

        public Bus GetBus(int busId)
        {
            return context.Bus.FirstOrDefault(id => id.BusId == busId);
        }

        public Bus GetBusFromBusOperatorId(string busOperatorId)
        {
            return context.Bus.FirstOrDefault(id => id.BusOperatorId == busOperatorId);
        }

        public Bus Update(Bus busChanges)
        {
            var bus = context.Bus.Attach(busChanges);
            bus.State = EntityState.Modified;
            context.SaveChanges();
            return busChanges;
        }

        public IEnumerable<Bus> FilterBusByBusTime(List<Bus> buses, string busTime)
        {
            return buses.FindAll(bus => bus.BusTime == busTime);
        }

        public IEnumerable<Bus> FilterBusByRatings(List<Bus> buses)
        {
            buses.Sort((b1, b2) =>
            {
                double r1 = Convert.ToDouble(b1.Ratings);
                double r2 = Convert.ToDouble(b2.Ratings);
                return r1.CompareTo(r2);
            });
            return buses;
        }
    }
}
