using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface IBusOperatorRepository
    {
        BusOperator Add(BusOperator busOperator);
        BusOperator Update(BusOperator busOperatorChanges);
        bool Delete(string busOperatorUserId);
        BusOperator GetBusOperator(string busOperatorUserId);
        IEnumerable<BusOperator> GetBusOperatorList();
    }
}