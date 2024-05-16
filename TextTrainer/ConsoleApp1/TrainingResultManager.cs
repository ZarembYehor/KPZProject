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
    }

}
