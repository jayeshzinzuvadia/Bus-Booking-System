using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Utilities
{
    public class DateUtility
    {
        public static string DateDifferenceFromToday(DateTime givenDate)
        {
            int days = (DateTime.Now - givenDate).Days;
            double month = (days / 30);
            if(month < 1)
            {
                return days + " Days";
            }
            double year = (days / 365);
            if(year < 1)
            {
                return month + " Months";
            }
            return year + " Years";
        }
    }
}
