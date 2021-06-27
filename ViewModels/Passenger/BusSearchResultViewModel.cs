using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Passenger
{
    public class BusSearchResultViewModel
    {
        public DateTime DateOfJourney { get; set; }        
        public BusTypes BusTypes { get; set; }
        public List<BusViewModel> BusList { get; set; }
    }
}
