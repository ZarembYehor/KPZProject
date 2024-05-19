using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrainingSessionResult
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double AccuracyPercentage { get; set; }
        public int CorrectChars { get; set; }
        public int TotalChars { get; set; }
        public bool IsAdvancedStrategy { get; set; }

        public override string ToString()
        {
            if (IsAdvancedStrategy)
            {
                return $"Start Time: {StartTime}, End Time: {EndTime}, Accuracy: {CorrectChars} / {TotalChars}";
            }
            else
            {
                return $"Start Time: {StartTime}, End Time: {EndTime}, Accuracy: {AccuracyPercentage:F2}%";
            }
        }
    }
}
