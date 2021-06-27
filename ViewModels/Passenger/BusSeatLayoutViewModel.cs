﻿using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Passenger
{
    public class BusSeatLayoutViewModel
    {
        public DateTime DateOfJourney { get; set; }
        public Bus Bus { get; set; }
        public BusRoute BusRoute { get; set; }
        public Seat Seat { get; set; }
        public List<int> BookedSeats { get; set; }
    }
}
