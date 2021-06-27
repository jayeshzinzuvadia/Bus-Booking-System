using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusBookingSystem.Utilities
{
    public class UniqueIdGenerator
    {
        public static string GenerateId(string prefix)
        {
            Thread.Sleep(1000);
            DateTimeOffset now = DateTimeOffset.UtcNow;
            //int year = now.Year;
            //year -= 2000;
            long num = (now.DayOfYear - 1) * 60 * ((60 * 23) + 56);
            num += (now.Hour * 60 * 60) + (now.Minute * 60) + now.Second;
            return prefix + ConvertIntoBase36(num);
        }

        public static string ConvertIntoBase36(long num)
        {
            string num36 = "";
            while (num != 0)
            {
                long temp = num % 36;
                if (temp < 10)
                {
                    num36 = temp + num36;
                }
                else
                {
                    num36 = (char)(temp + 65 - 10) + num36;
                }
                num /= 36;
            }
            return num36;
        }
    }
}
