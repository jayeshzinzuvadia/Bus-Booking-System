using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusBookingSystem.Models.Entities
{
    public enum Banks
    {
        [Display(Name = "State Bank Of India")]
        StateBankOfIndia = 1,        
        [Display(Name = "HDFC Bank")]
        HDFCBank = 2,
        [Display(Name = "ICICI Bank")]
        ICICIBank = 3,
        [Display(Name = "AXIS Bank")]
        AXISBank = 4,
        [Display(Name = "Kotak Mahindra Bank")]
        KotakMahindraBank = 5,
    }

    public class Transaction
    {
        // Composite key - TicketId and PassengerInfoId
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public int PassengerInfoId { get; set; }
        public PassengerInfo PassengerInfo { get; set; }        
    }
}
