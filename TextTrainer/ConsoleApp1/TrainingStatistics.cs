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
            Console.WriteLine("Training Statistics:");
            Console.WriteLine($"Average Training Time: {_resultManager.GetAverageTrainingTime()} seconds");
            Console.WriteLine($"Best Accuracy: {_resultManager.GetBestAccuracy()}%");
            Console.WriteLine($"Worst Accuracy: {_resultManager.GetWorstAccuracy()}%");
            Console.WriteLine($"Total Training Sessions: {_resultManager.GetTotalTrainingSessions()}");
        }
    }
}
