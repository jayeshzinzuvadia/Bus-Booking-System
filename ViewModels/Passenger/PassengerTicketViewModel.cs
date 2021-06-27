using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Passenger
{
    public class PassengerTicketViewModel
    {
        public Ticket Ticket { get; set; }
        public List<PassengerInfo> Passengers { get; set; }
    }
}
