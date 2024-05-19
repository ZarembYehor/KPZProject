using System;
using System.Diagnostics;

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

        public void StartSession()
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

            RecordResult(sessionResult);

            _stopwatch.Reset();
        }

        private void RecordResult(string sessionResult)
        {
            var result = new TrainingSessionResult
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddSeconds(_stopwatch.Elapsed.TotalSeconds)
            };

            if (_accuracyStrategy is AdvancedAccuracyStrategy)
            {
                var parts = sessionResult.Split('/');
                result.CorrectChars = int.Parse(parts[0].Trim());
                result.TotalChars = int.Parse(parts[1].Trim());
                result.IsAdvancedStrategy = true;
            }
            else
            {
                result.AccuracyPercentage = double.Parse(sessionResult);
                result.IsAdvancedStrategy = false;
            }

            _resultManager.AddResult(result);
        }
    }
}
