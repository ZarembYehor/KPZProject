using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class BasicAccuracyStrategy : IAccuracyCalculationStrategy
    {
        private List<double> sessionAccuracies = new List<double>();

        public string CalculateAccuracy(string expectedText, string actualText)
        {
            int correctChars = expectedText.Zip(actualText, (e, a) => e == a).Count(isCorrect => isCorrect);
            int totalChars = expectedText.Length;

            double accuracy = (double)correctChars / totalChars * 100;
            sessionAccuracies.Add(accuracy);

            return $"{accuracy:F2}";
        }

        public string CalculateOverallAccuracy()
        {
            if (sessionAccuracies.Count == 0) return "0.00";

            double overallAccuracy = sessionAccuracies.Average();
            return $"{overallAccuracy:F2}%";
        }
    }
}
