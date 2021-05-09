using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public static class BinFunctions
    {
        public static Random random = new Random();

        public static string GetBinValue(Dictionary<string, double> bins)
        {
            double totalProb = 0;
            foreach (var key in bins.Keys) {
                totalProb += bins[key];
            }

            var scale = 1 / totalProb;
            var roll = random.NextDouble() / scale;

            double sum = 0;
            foreach (var key in bins.Keys)
            {
                sum += bins[key];
                if (roll <= sum)
                    return key;
            }

            return "ERROR";
        }


    }
}
