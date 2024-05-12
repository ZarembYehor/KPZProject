using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BasicAccuracyStrategy : IAccuracyCalculationStrategy
    {
        public double CalculateAccuracy(string expectedText, string actualText)
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

            return (double)correctChars / totalChars * 100;
        }
    }
}
