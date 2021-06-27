using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.BusOperator
{
    public class PassengerCheckListViewModel
    {
        public PassengerInfo Passenger { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TicketId { get; set; }
        public bool IsChecked { get; set; }
    }
}
