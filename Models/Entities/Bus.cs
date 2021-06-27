using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusBookingSystem.Models.Entities
{
    public enum BusTypes
    {
        Seater = 1, Sleeper = 2, AC = 3
    }

    public class Bus
    {
        public int BusId { get; set; }

        [Required]
        [Display(Name = "Name of Bus")]
        public string BusName { get; set; }
        
        // Filters
        public BusTypes BusType { get; set; }

        [Display(Name = "Bus Time")]
        public string BusTime { get; set; }
        public string Ratings { get; set; }
        public int TotalRateCounts { get; set; }

        [Required]
        [Display(Name = "Total Seat")]
        public int TotalSeat { get; set; }

        [Required]
        [Display(Name = "Bus Vehicle Number")]
        public string BusVehicleNumber { get; set; }

        [Required]
        [Display(Name = "Route Sequence")]
        public string RouteSequence { get; set; }

        //UserId of BusOperator as foreign key
        //One to One Relationship between BusOperator and Bus
        [Display(Name = "Bus Operator Name")]
        public string BusOperatorId { get; set; }
        public BusOperator BusOperator { get; set; }

        //One to many relationship between BusRoute and Bus
        public ICollection<BusRoute> BusRoutes { get; set; }
    }
}
