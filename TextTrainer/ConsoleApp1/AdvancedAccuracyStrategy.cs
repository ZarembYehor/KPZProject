using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AdvancedAccuracyStrategy : IAccuracyCalculationStrategy
    {
        private List<int> sessionCorrectChars = new List<int>();
        private List<int> sessionTotalChars = new List<int>();

        public string CalculateAccuracy(string expectedText, string actualText)
        {
            int totalChars = expectedText.Length;
            int correctChars = 0;

            for (int i = 0; i < totalChars; i++)
            {
                if (i < actualText.Length && expectedText[i] == actualText[i])
                {
                    correctChars++;
                }
            }

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
