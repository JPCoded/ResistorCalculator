using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistorCalculator
{
    public static class ExtensionMethods
    {
        public static string GetOhmage(this double value)
        {
            var returnValue = "";
            if (value > 1e6)
            {
                value /= 1e6;
                returnValue = value + "M ";
            }
            else
            {
                if (value > 1e3)
                {
                    value /= 1e3;
                    returnValue = value + "K ";
                }
                else
                {
                    returnValue = value.ToString();
                }
            }
            return returnValue;
        }
    }
}
