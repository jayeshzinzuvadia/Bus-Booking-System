using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Passenger
{
    public class ManageBookingsViewModel
    {
        [Required]
        [Display(Name = "Ticket ID")]
        public int TicketId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Passenger Email")]
        public string PEmail { get; set; }
    }
}
