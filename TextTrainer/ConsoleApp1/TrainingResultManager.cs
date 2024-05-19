using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrainingResultManager
    {
        private List<TrainingSessionResult> _sessionResults;

        public TrainingResultManager()
        {
            _sessionResults = new List<TrainingSessionResult>();
        }

        public void AddResult(TrainingSessionResult result)
        {
            _sessionResults.Add(result);
        }

        public void SaveResultsToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (TrainingSessionResult result in _sessionResults)
                    {
                        writer.WriteLine(result.ToString());
                    }
                }
                Console.WriteLine("Results saved successfully to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving results to file: {ex.Message}");
            }
        }

        public void PrintTrainingHistory()
        {
            Console.WriteLine("Training History:");
            Console.WriteLine("-----------------");
            foreach (TrainingSessionResult result in _sessionResults)
            {
                Console.WriteLine(result);
            }
        }

        public void PrintExtendedStatistics()
        {
            double totalAccuracy = 0;
            double totalTime = 0;
            int sessionCount = _sessionResults.Count;

            foreach (var result in _sessionResults)
            {
                if (result.IsAdvancedStrategy)
                {
                    totalAccuracy += (double)result.CorrectChars / result.TotalChars * 100;
                }
                else
                {
                    totalAccuracy += result.AccuracyPercentage;
                }
                totalTime += (result.EndTime - result.StartTime).TotalSeconds;
            }

            double averageAccuracy = totalAccuracy / sessionCount;
            double averageTimePerSession = totalTime / sessionCount;

            Console.WriteLine("Extended Statistics:");
            Console.WriteLine($"Average Accuracy: {averageAccuracy:F2}%");
            Console.WriteLine($"Average Time Per Session: {averageTimePerSession:F2} seconds");
        }

        public TimeSpan GetAverageTrainingTime()
        {
            double totalSeconds = _sessionResults.Select(r => (r.EndTime - r.StartTime).TotalSeconds).Sum();
            int count = _sessionResults.Count;
            return TimeSpan.FromSeconds(totalSeconds / count);
        }

        public double GetBestAccuracy()
        {
            return _sessionResults.Max(r => r.IsAdvancedStrategy
                ? (double)r.CorrectChars / r.TotalChars * 100
                : r.AccuracyPercentage);
        }

        public double GetWorstAccuracy()
        {
            return _sessionResults.Min(r => r.IsAdvancedStrategy
                ? (double)r.CorrectChars / r.TotalChars * 100
                : r.AccuracyPercentage);
        }

        public int GetTotalTrainingSessions()
        {
            return _sessionResults.Count;
        }
    }


}
