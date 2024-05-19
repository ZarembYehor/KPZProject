using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BasicAccuracyStrategy : IAccuracyCalculationStrategy
    {
        private List<string> sessionResults = new List<string>();

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

            double accuracy = (double)correctChars / totalChars * 100;

            string result = $"{accuracy:F2}";
            this.sessionResults.Add(result);

            return result;
        }

        public string CalculateOverallAccuracy()
        {
            double totalAccuracy = 0;

            foreach (string result in this.sessionResults)
            {
                Console.WriteLine(result);
                if (double.TryParse(result, out double accuracy))
                {
                    totalAccuracy += accuracy;
                }
            }

            double overallAccuracy = totalAccuracy / this.sessionResults.Count;
            return $"Overall Accuracy: {overallAccuracy:F2}%";
        }
    }
}
