using ConsoleApp1;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

var eventNotifier = new EventNotifier();
var resultManager = new TrainingResultManager();
var chooseDifficulty = new TrainingDifficultyManager();

while (true)
{
    Console.WriteLine("Виберіть тип оцінювання (1 для Basic, 2 для Advanced):");
    string accuracyChoice = Console.ReadLine();
    IAccuracyCalculationStrategy accuracyStrategy;

    switch (accuracyChoice)
    {
        case "1":
            accuracyStrategy = new BasicAccuracyStrategy();
            break;
        case "2":
            accuracyStrategy = new AdvancedAccuracyStrategy();
            break;
        default:
            Console.WriteLine("Неправильний вибір. Використовується Basic оцінювання за замовчуванням.");
            accuracyStrategy = new BasicAccuracyStrategy();
            break;
    }

    Console.WriteLine("Виберіть складність (1 для Easy, 2 для Medium, 3 для Hard):");
    string difficultyChoice = Console.ReadLine();
    DifficultyLevel difficulty;

    switch (difficultyChoice)
    {
        case "1":
            difficulty = DifficultyLevel.Easy;
            break;
        case "2":
            difficulty = DifficultyLevel.Medium;
            break;
        case "3":
            difficulty = DifficultyLevel.Hard;
            break;
        default:
            Console.WriteLine("Неправильний вибір. Використовується Easy складність за замовчуванням.");
            difficulty = DifficultyLevel.Easy;
            break;
    }

    int sessionCount;
    while (true)
    {
        Console.WriteLine("Введіть кількість підходів у сесії:");
        if (int.TryParse(Console.ReadLine(), out sessionCount) && sessionCount > 0)
        {
            break;
        }
        Console.WriteLine("Будь ласка, введіть дійсне число більше 0.");
    }

    for (int i = 0; i < sessionCount; i++)
    {
        var session = new TrainingSession(accuracyStrategy, eventNotifier, resultManager, chooseDifficulty, difficulty);
        session.StartSession();
    }

    Console.WriteLine("Бажаєте зберегти відомість про проходження тестування у файл? (yes/no):");
    string saveToFileChoice = Console.ReadLine();

    if (saveToFileChoice.Equals("yes", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Введіть назву файлу для збереження результатів:");
        string fileName = Console.ReadLine();
        resultManager.SaveResultsToFile(fileName);
    }
    var statistics = new TrainingStatistics(resultManager);
    statistics.DisplayStatistics();

    Console.WriteLine("Введіть 'exit' для завершення програми або будь-який інший текст для нового сеансу:");
    string exitChoice = Console.ReadLine();
    if (exitChoice.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }
}
