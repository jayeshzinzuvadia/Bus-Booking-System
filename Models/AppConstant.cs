using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusBookingSystem.Models
{
    public static class AppConstant
    {
        // User constants
        public const string PASSENGER = "Passenger";
        public const string BUS_OPERATOR = "Bus Operator";
        public const string BUSOPERATOR_CONTROLLER = "BusOperator";
        public const string ADMIN = "Admin";
        public const string MASTER = "Master";

        // Fee constants
        public const int RESERVATION_FEE = 5;
        public const int TOLL_FEE = 5;

        // Ticket Status
        public const string BOOKED = "Booked";
        public const string CANCELLED = "Cancelled";
        public const string CHECKED = "Checked";
        public const string RATED = "Rated";

        // Organizaion's Email Information
        // Very Confidential Information
        public const string ORGANIZATION_NAME = "Bus Booking System Project";
        public const string ORGANIZATION_EMAIL_ADDRESS = "busbookingsystem7@gmail.com";
        public const string ORGANIZATION_PASSWORD = "BusBookingSystem@7";
        public const string SMTP_ADDRESS = "smtp.gmail.com";
        public const int SMTP_PORT = 587;

        public static List<KeyValuePair<string, string>> GenderList;
        static AppConstant()
        {
            GenderList = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(Gender.Male.ToString(),"Male"),
                new KeyValuePair<string, string>(Gender.Female.ToString(),"Female"),
            };
        }
    }
}
