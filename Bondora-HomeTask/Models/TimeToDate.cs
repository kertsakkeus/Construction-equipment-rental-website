using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bondora_HomeTask.Models
{
    public class TimeToDate
    {
        public static string GetDate(int time)
        {
            if (time == 1)
            {
                return time.ToString() + " Day";
            }
            else if (time <= 7)
            {
                return time.ToString() + " Days";
            }
            else if (time == 14)
            {
                return "2 Weeks";
            }
            else if (time == 30)
            {
                return "1 Month";
            }
            else if (time == 90)
            {
                return "3 Months";
            }
            else if (time == 180)
            {
                return "6 Months";
            }
            else if (time == 365)
            {
                return "1 Year";
            }
            else
            {
                return time + " Days";
            }
        }
    }
}