using ConsoleApp1;

TrainingResultManager resultManager = new TrainingResultManager();

// Проведення тренувальних сесій і збереження результатів
for (int i = 0; i < 3; i++)
{
    TrainingSessionResult sessionResult = ConductTrainingSession();
    resultManager.AddResult(sessionResult);
    Console.WriteLine($"Training Session {i + 1} completed.");
    Console.WriteLine();
}

// Виведення історії тренувань
resultManager.PrintTrainingHistory();

// Збереження історії тренувань у файл
resultManager.SaveResultsToFile("training_history.txt");

static TrainingSessionResult ConductTrainingSession()
{
    // Симулюємо тренувальну сесію і отримуємо результат
    TrainingSessionResult sessionResult = new TrainingSessionResult();
    sessionResult.StartTime = DateTime.Now;

    // Припустимо, що тренувальна сесія триває 5 секунд
    Thread.Sleep(5000);

    // Генеруємо випадкову точність для прикладу
    Random rand = new Random();
    sessionResult.Accuracy = $"{rand.NextDouble() * 100}";

    sessionResult.EndTime = DateTime.Now;
    return sessionResult;
}
/*
static void TestBasicAccuracyStrategy()
{
    var accuracyStrategy = new BasicAccuracyStrategy();
    var eventNotifier = new EventNotifier();

    var trainingSession = new TrainingSession(accuracyStrategy, eventNotifier);
    List<string> sessionResults = new List<string>();

    Console.WriteLine("Basic Accuracy Strategy Test:");
    Console.WriteLine("-------------------------------");

    // Початок відліку часу
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Training Session {i + 1}:");
        Console.WriteLine("-------------------------------");
        trainingSession.StartSession();
        sessionResults.Add(trainingSession.GetTotalTimeInSeconds().ToString()); // Додаємо час сесії до списку результатів
        Console.WriteLine();
    }

    // Зупинка таймера
    stopwatch.Stop();

    // Виведення часу виконання тесту
    Console.WriteLine($"Total time taken: {stopwatch.Elapsed.TotalSeconds} seconds");

    // Розрахунок загальної точності і виведення результатів
    // (код для обчислення загальної точності)
}

static void TestAdvancedAccuracyStrategy()
{
    var accuracyStrategy = new AdvancedAccuracyStrategy();
    var eventNotifier = new EventNotifier();

    var trainingSession = new TrainingSession(accuracyStrategy, eventNotifier);
    List<string> sessionResults = new List<string>();

    Console.WriteLine("Advanced Accuracy Strategy Test:");
    Console.WriteLine("-------------------------------");

    // Початок відліку часу
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Training Session {i + 1}:");
        Console.WriteLine("-------------------------------");
        trainingSession.StartSession();
        sessionResults.Add(trainingSession.GetTotalTimeInSeconds().ToString()); // Додаємо час сесії до списку результатів
        Console.WriteLine();
    }

    // Зупинка таймера
    stopwatch.Stop();

    // Виведення часу виконання тесту
    Console.WriteLine($"Total time taken: {stopwatch.Elapsed.TotalSeconds} seconds");

    // Розрахунок загальної точності і виведення результатів
    // (код для обчислення загальної точності)
}
*/