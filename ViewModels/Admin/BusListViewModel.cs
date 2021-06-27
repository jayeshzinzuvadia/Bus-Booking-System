using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Admin
{
    public class BusListViewModel
    {
        public Bus Bus { get; set; }
        public string BusOperatorName { get; set; }
    }
}
