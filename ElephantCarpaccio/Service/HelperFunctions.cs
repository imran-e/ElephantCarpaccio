using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElephantCarpaccio.Service
{
    public class HelperFunctions
    {
        public static Dictionary<string, string> GetStateCode()
        {
            return new Dictionary<string, string>
            {
                {"UTAH",  "UT"},
                {"NEVADA", "NV"},
                {"TEXAS", "TX"},
                {"ALABAMA", "AL"},
                {"CALIFORNIA", "CA"}
            };
        }

        public static Dictionary<string, decimal> GetStateTax()
        {
            return new Dictionary<string, decimal>
            {
                {"UT", 6.85M },
                {"NV", 8.0M },
                {"TX", 6.25M },
                {"AL", 4.0M },
                {"CA", 8.25M },
            };
        }

        public static int GetDiscountRate(decimal productPrice)
        {
            switch (productPrice)
            {
                case var between1000And5000 when (productPrice > 1000M && productPrice < 5000M):
                    return 3;
                case var between5000And7000 when (productPrice > 5000M && productPrice < 7000M):
                    return 5;
                case var between7000And10000 when (productPrice > 7000M && productPrice < 10000M):
                    return 7;
                case var between10000And50000 when (productPrice > 10000M && productPrice < 50000M):
                    return 10;
                case 50000:
                    return 15;
                default:
                    return 0;
            }
        }
    }
}
