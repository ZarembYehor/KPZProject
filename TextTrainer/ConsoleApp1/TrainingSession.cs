using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrainingSession
    {
        private readonly IAccuracyCalculationStrategy _accuracyStrategy;
        private readonly EventNotifier _eventNotifier;

        public TrainingSession(IAccuracyCalculationStrategy accuracyStrategy, EventNotifier eventNotifier)
        {
            _accuracyStrategy = accuracyStrategy;
            _eventNotifier = eventNotifier;
        }

        public void StartSession()
        {
            var textProvider = TextProvider.Instance;
            var randomWords = textProvider.GetRandomWords(1);
            var textToType = string.Join(" ", randomWords); 
            Console.WriteLine("Type the following text:");
            Console.WriteLine(textToType);

            var userInput = Console.ReadLine();

            var accuracy = _accuracyStrategy.CalculateAccuracy(textToType, userInput);

            Console.WriteLine($"Your accuracy: {accuracy}%");

            _eventNotifier.NotifyObservers();
        }
    }
}
