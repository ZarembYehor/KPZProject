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
        private readonly DifficultyLevel _difficulty;
        private readonly TrainingDifficultyManager _chooseDifficulty;

        public TrainingSession(IAccuracyCalculationStrategy accuracyStrategy, EventNotifier eventNotifier, TrainingResultManager resultManager, TrainingDifficultyManager chooseDifficulty, DifficultyLevel difficulty)
        {
            _accuracyStrategy = accuracyStrategy;
            _eventNotifier = eventNotifier;
            _stopwatch = new Stopwatch();
            _resultManager = resultManager;
            _chooseDifficulty = chooseDifficulty;
            _difficulty = difficulty;
        }

        public string StartSession()
        {
            _stopwatch.Start();
            var textProvider = TextProvider.Instance;
            var randomWords = textProvider.GetRandomWords(_chooseDifficulty.GetWordCountForDifficulty(_difficulty));
            var textToType = string.Join(" ", randomWords);
            Console.WriteLine("Type the following text:");
            Console.WriteLine(textToType);

            var userInput = Console.ReadLine();

            string sessionResult = _accuracyStrategy.CalculateAccuracy(textToType, userInput);

            Console.WriteLine($"Your result: {sessionResult}");

            _eventNotifier.NotifyObservers();

            _stopwatch.Stop();

            if (_accuracyStrategy is AdvancedAccuracyStrategy)
            {
                var parts = sessionResult.Split('/');
                int correctChars = int.Parse(parts[0].Trim());
                int totalChars = int.Parse(parts[1].Trim());

                _resultManager.AddResult(new TrainingSessionResult
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddSeconds(_stopwatch.Elapsed.TotalSeconds),
                    CorrectChars = correctChars,
                    TotalChars = totalChars,
                    IsAdvancedStrategy = true
                });
            }
            else
            {
                _resultManager.AddResult(new TrainingSessionResult
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddSeconds(_stopwatch.Elapsed.TotalSeconds),
                    AccuracyPercentage = double.Parse(sessionResult),
                    IsAdvancedStrategy = false
                });
            }

            return sessionResult;
        }

        public double GetTotalTimeInSeconds()
        {
            return _stopwatch.Elapsed.TotalSeconds;
        }
    }

}