using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrainingSession
    {
        private readonly IAccuracyCalculationStrategy _accuracyStrategy;
        private readonly EventNotifier _eventNotifier;
        private readonly Stopwatch _stopwatch;
        private readonly TrainingResultManager _resultManager;

        public TrainingSession(IAccuracyCalculationStrategy accuracyStrategy, EventNotifier eventNotifier, TrainingResultManager resultManager)
        {
            _accuracyStrategy = accuracyStrategy;
            _eventNotifier = eventNotifier;
            _stopwatch = new Stopwatch();
            _resultManager = resultManager;
        }

        public void StartSession()
        {
            _stopwatch.Start();
            var textProvider = TextProvider.Instance;
            var randomWords = textProvider.GetRandomWords(1);
            var textToType = string.Join(" ", randomWords);
            Console.WriteLine("Type the following text:");
            Console.WriteLine(textToType);

            var userInput = Console.ReadLine();

            string sessionResult = _accuracyStrategy.CalculateAccuracy(textToType, userInput);

            Console.WriteLine($"Your result: {sessionResult}");

            _eventNotifier.NotifyObservers();

            _stopwatch.Stop();

            _resultManager.AddResult(new TrainingSessionResult
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Accuracy = sessionResult
            });
        }

        public double GetTotalTimeInSeconds()
        {
            return _stopwatch.Elapsed.TotalSeconds;
        }
    }
}