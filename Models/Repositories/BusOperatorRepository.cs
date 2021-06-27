using BusBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BusBookingSystem.Models.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusBookingSystem.Models.Repositories
{
    public class BusOperatorRepository : IBusOperatorRepository
    {
        private readonly AppDbContext context;
        public BusOperatorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public BusOperator Add(BusOperator busOperator)
        {
            context.BusOperator.Add(busOperator);
            context.SaveChanges();
            return busOperator;
        }

        public bool Delete(string busOperatorUserId)
        {
            BusOperator user = GetBusOperator(busOperatorUserId);
            if (user != null)
            {
                context.BusOperator.Remove(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public BusOperator GetBusOperator(string busOperatorUserId)
        {
            return context.BusOperator.Find(busOperatorUserId);
        }

        public IEnumerable<BusOperator> GetBusOperatorList()
        {
            return context.BusOperator;
        }

        public BusOperator Update(BusOperator busOperatorChanges)
        {
            var busOperator = context.BusOperator.Attach(busOperatorChanges);
            busOperator.State = EntityState.Modified;
            context.SaveChanges();
            return busOperatorChanges;
        }
    }
}
