using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Passenger
{
    public class PassengerInfoViewModel
    {
        public List<PassengerInfo> PInfo { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string PEmail { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PPhoneNumber { get; set; }
    }
}
