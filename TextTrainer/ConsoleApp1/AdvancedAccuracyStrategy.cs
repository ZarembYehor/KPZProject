using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class AdvancedAccuracyStrategy : IAccuracyCalculationStrategy
    {
        private List<int> sessionCorrectChars = new List<int>();
        private List<int> sessionTotalChars = new List<int>();

        public string CalculateAccuracy(string expectedText, string actualText)
        {
            int correctChars = expectedText.Zip(actualText, (e, a) => e == a).Count(isCorrect => isCorrect);
            int totalChars = expectedText.Length;

            sessionCorrectChars.Add(correctChars);
            sessionTotalChars.Add(totalChars);

            return $"{correctChars} / {totalChars}";
        }
        public string CalculateOverallAccuracy()
        {
            int totalCorrectChars = sessionCorrectChars.Sum();
            int totalChars = sessionTotalChars.Sum();

            return $"{totalCorrectChars} / {totalChars}";
        }
    }
}
