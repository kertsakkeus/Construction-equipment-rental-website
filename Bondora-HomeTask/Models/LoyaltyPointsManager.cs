using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bondora_HomeTask.Models
{
    public class LoyaltyPointsManager
    {
        public static int GetPoints(string type)
        {
            if (type == Types.Heavy)
            {
                return 2;
            }
            return 1;
        }
    }
}