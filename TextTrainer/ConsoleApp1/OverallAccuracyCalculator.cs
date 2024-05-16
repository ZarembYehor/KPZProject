using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OverallAccuracyCalculator
    {
        public double CalculateOverallAccuracy(List<double> sessionAccuracies)
        {
            if (sessionAccuracies == null || sessionAccuracies.Count == 0)
                return 0;

            double totalAccuracy = sessionAccuracies.Sum();
            return totalAccuracy / sessionAccuracies.Count;
        }
    }
}
