using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Admin
{
    public class BusRouteListViewModel
    {
        public Bus Bus { get; set; }

        [Display(Name = "Bus Operator Name")]
        public string BusOperatorName { get; set; }

        public List<BusRoute> BusRouteList { get; set; }
    }
}
