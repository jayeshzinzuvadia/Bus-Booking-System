using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.ViewModels.Passenger
{
    public class TicketPaymentViewModel
    {
        [Display(Name = "Ticket Price")]
        public int TicketPrice { get; set; }

        [Display(Name = "Total Amount")]
        public int TotalAmount { get; set; }

        [Required]
        [Display(Name = "Select Bank")]
        public Banks BankName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(6)]
        [Display(Name = "Bank Secret Code (6 digits)")]
        public string BankSecretCode { get; set; }
    }
}
