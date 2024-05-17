using ConsoleApp1;

var accuracyStrategy = new BasicAccuracyStrategy();
var eventNotifier = new EventNotifier();
var resultManager = new TrainingResultManager();
var chooseDifficulty = new TrainingDifficultyManager();

Console.WriteLine("Choose training difficulty:");
Console.WriteLine("1. Easy");
Console.WriteLine("2. Medium");
Console.WriteLine("3. Hard");
Console.Write("Enter your choice: ");

int choice;
while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
{
    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
    Console.Write("Enter your choice: ");
}

DifficultyLevel difficulty;
switch (choice)
{
    case 1:
        difficulty = DifficultyLevel.Easy;
        break;
    case 2:
        difficulty = DifficultyLevel.Medium;
        break;
    case 3:
        difficulty = DifficultyLevel.Hard;
        break;
    default:
        throw new ArgumentException("Invalid choice.");
}

var trainingSession = new TrainingSession(accuracyStrategy, eventNotifier, resultManager, chooseDifficulty, difficulty);

Console.WriteLine($"Training Session (Difficulty: {difficulty}):");
Console.WriteLine("-------------------------------");

double totalAccuracy = 0;
double totalTime = 0;

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Training Session {i + 1}:");
    Console.WriteLine("-------------------------------");
    var sessionResult = trainingSession.StartSession();
    totalAccuracy += double.Parse(sessionResult.Substring(0, sessionResult.Length - 1));
    totalTime += trainingSession.GetTotalTimeInSeconds();
    Console.WriteLine();
}

string overallAccuracy = accuracyStrategy.CalculateOverallAccuracy();
Console.WriteLine($"Overall Accuracy: {overallAccuracy}");

Console.WriteLine($"Total Training Time: {TimeSpan.FromSeconds(totalTime)}");

resultManager.SaveResultsToFile("training_results.txt");