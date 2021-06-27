using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface IPassengerInfoRepository
    {
        PassengerInfo Add(PassengerInfo passengerInfo);
        PassengerInfo Update(PassengerInfo passengerInfoChanges);
        bool Delete(int passengerInfoId);
        PassengerInfo GetPassengerInfo(int passengerInfoId);
    }
}
