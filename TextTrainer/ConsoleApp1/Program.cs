using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            var eventNotifier = new EventNotifier();
            var resultManager = new TrainingResultManager();
            var chooseDifficulty = new TrainingDifficultyManager();

            while (true)
            {
                var menuBuilder = new StringBuilder();

                menuBuilder.AppendLine("Виберіть дію:");
                menuBuilder.AppendLine("1. Почати гру");
                menuBuilder.AppendLine("2. Переглянути статистику");
                menuBuilder.AppendLine("3. Вийти");

                Console.WriteLine(menuBuilder.ToString());

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var accuracyStrategy = ChooseAccuracyStrategy();
                        var difficulty = ChooseDifficulty();
                        int sessionCount = GetSessionCount();

                        for (int i = 0; i < sessionCount; i++)
                        {
                            var session = new TrainingSession(accuracyStrategy, eventNotifier, resultManager, chooseDifficulty, difficulty);
                            session.StartSession();
                        }

                        resultManager.SaveResultsToFile();
                        var statistics = new TrainingStatistics(resultManager);
                        statistics.DisplayStatistics();
                        break;
                    case "2":
                        Console.WriteLine("Перегляд статистики:");
                        string defaultFilePath = resultManager.GetDefaultFilePath();
                        resultManager.LoadAndPrintStatisticsFromFile(defaultFilePath);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static IAccuracyCalculationStrategy ChooseAccuracyStrategy()
        {
            Console.WriteLine("Виберіть тип оцінювання (1 для Basic, 2 для Advanced):");
            string strategyChoice = Console.ReadLine();

            return strategyChoice switch
            {
                "1" => new BasicAccuracyStrategy(),
                "2" => new AdvancedAccuracyStrategy(),
                _ => throw new InvalidOperationException("Невірний вибір стратегії."),
            };
        }

        static DifficultyLevel ChooseDifficulty()
        {
            Console.WriteLine("Виберіть рівень складності (1 для Легкого, 2 для Середнього, 3 для Важкого):");
            string difficultyChoice = Console.ReadLine();

            return difficultyChoice switch
            {
                "1" => DifficultyLevel.Easy,
                "2" => DifficultyLevel.Medium,
                "3" => DifficultyLevel.Hard,
                _ => throw new InvalidOperationException("Невірний вибір рівня складності."),
            };
        }

        static int GetSessionCount()
        {
            Console.WriteLine("Введіть кількість сесій для тренування:");
            if (int.TryParse(Console.ReadLine(), out int sessionCount))
            {
                return sessionCount;
            }
            else
            {
                Console.WriteLine("Невірний ввід, встановлено значення за замовчуванням: 1.");
                return 1;
            }
        }
    }
}
