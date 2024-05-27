using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrainingStatistics
    {
        private readonly TrainingResultManager _resultManager;

        public TrainingStatistics(TrainingResultManager resultManager)
        {
            _resultManager = resultManager;
        }

        public void DisplayStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Training Statistics:");
            sb.AppendLine($"Average Training Time: {_resultManager.GetAverageTrainingTime()} seconds");
            sb.AppendLine($"Best Accuracy: {_resultManager.GetBestAccuracy()}%");
            sb.AppendLine($"Worst Accuracy: {_resultManager.GetWorstAccuracy()}%");
            sb.AppendLine($"Total Training Sessions: {_resultManager.GetTotalTrainingSessions()}");

            string result = sb.ToString();
            Console.WriteLine(result);
        }
    }
}
