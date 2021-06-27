using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusBookingSystem.Models.Entities
{
    public class BusOperator : ApplicationUser
    {
        public string Address { get; set; }
        public int Salary { get; set; }

        public DateTime DateOfJoining { get; set; }

        [NotMapped]
        public int? Experience { get; set; }

        //One to One Relationship between Bus class
        public Bus Bus { get; set; }
    }
}
