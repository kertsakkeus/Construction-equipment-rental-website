using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bondora_HomeTask.Models
{
    public class TypeColorController
    {
        public static string GetColor(string type)
        {
            if (type == Types.Regular)
            {
                return "#bbe432";
            }
            else if (type == Types.Heavy)
            {
                return "#ff3b3b";
            }
            else if (type == Types.Specialized)
            {
                return "#006ccb";
            }
            else
            {
                return "#ffffff";
            }
        }
    }
}