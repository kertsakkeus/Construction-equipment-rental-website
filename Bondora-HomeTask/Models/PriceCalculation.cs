using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bondora_HomeTask.Models
{
    public class PriceCalculation
    {

        static int OneTime = 100;
        static int Premium = 60;
        static int Regular = 40;

        public static int EquipmentPrice(string type, int rentTime)
        {
            int rentalPrice;
            if (type == Types.Regular)
            {
                if (rentTime <= 2)
                {
                    rentalPrice = OneTime + (Premium * rentTime);
                    return rentalPrice;
                }
                else
                {
                    rentalPrice = OneTime + (Premium * 2) + (Regular * rentTime);
                    return rentalPrice;
                }
            }
            else if (type == Types.Heavy)
            {
                rentalPrice = OneTime + (Premium * rentTime);
                return rentalPrice;
            }
            else if (type == Types.Specialized)
            {
                if (rentTime <= 3)
                {
                    rentalPrice = Premium * rentTime;
                    return rentalPrice;
                }
                else
                {
                    rentalPrice = (Premium * 3) + (Regular * rentTime);
                    return rentalPrice;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}