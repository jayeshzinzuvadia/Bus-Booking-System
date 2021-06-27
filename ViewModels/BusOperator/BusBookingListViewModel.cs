using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.BusOperator
{
    public class BusBookingListViewModel
    {
        public PassengerInfo Passenger { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}
