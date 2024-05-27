using System.Text;

namespace ConsoleApp1;

public class TrainingResultManager
{
    private List<TrainingSessionResult> _sessionResults;
    private string _defaultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "default_results.txt");
    private double _bestAccuracy = 0;
    private TimeSpan _bestTime = TimeSpan.MaxValue;
    private string _selectedStrategy = "";
    private int _sessionCount = 0;

    public TrainingResultManager()
    {
        _sessionResults = new List<TrainingSessionResult>();
    }

    public void AddResult(TrainingSessionResult result)
    {
        _sessionResults.Add(result);
        _sessionCount++;
        UpdateBestResults(result);
        SaveResultsToFile();
    }

    private void UpdateBestResults(TrainingSessionResult result)
    {
        double accuracy = result.IsAdvancedStrategy ? (double)result.CorrectChars / result.TotalChars * 100 : result.AccuracyPercentage;

        if (accuracy > _bestAccuracy)
        {
            _bestAccuracy = accuracy;
            _bestTime = result.EndTime - result.StartTime;
            _selectedStrategy = result.IsAdvancedStrategy ? "Advanced" : "Basic";
        }
    }

    public void SaveResultsToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_defaultFilePath))
            {
                foreach (TrainingSessionResult result in _sessionResults)
                {
                    writer.WriteLine(result.ToString());
                }
                writer.WriteLine($"Best Accuracy: {_bestAccuracy:F2}%");
                writer.WriteLine($"Best Time: {_bestTime.TotalSeconds} seconds");
                writer.WriteLine($"Selected Strategy: {_selectedStrategy}");
                writer.WriteLine($"Total Sessions: {_sessionCount}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving results to file: {ex.Message}");
        }
    }

    public void LoadAndPrintStatisticsFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("Завантажена статистика:");
                Console.WriteLine("-------------------");
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Файл не знайдено за шляхом: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка під час завантаження статистики з файлу: {ex.Message}");
        }
    }

    public string GetDefaultFilePath() => _defaultFilePath;

    public void PrintTrainingHistory()
    {
        Console.WriteLine("Історія тренувань:");
        Console.WriteLine("-----------------");
        foreach (TrainingSessionResult result in _sessionResults)
        {
            Console.WriteLine(result);
        }
    }

    public void PrintExtendedStatistics()
    {
        double totalAccuracy = _sessionResults.Sum(r => r.IsAdvancedStrategy ? (double)r.CorrectChars / r.TotalChars * 100 : r.AccuracyPercentage);
        double totalTime = _sessionResults.Sum(r => (r.EndTime - r.StartTime).TotalSeconds);
        int sessionCount = _sessionResults.Count;

        double averageAccuracy = totalAccuracy / sessionCount;
        double averageTimePerSession = totalTime / sessionCount;

        var extendedStatisticsBuilder = new StringBuilder();
        extendedStatisticsBuilder.AppendLine("Розширена статистика:");
        extendedStatisticsBuilder.AppendLine($"Середня точність: **{averageAccuracy:F2}%**");
        extendedStatisticsBuilder.AppendLine($"Середній час на сесію: **{averageTimePerSession:F2}** секунд");

        Console.WriteLine(extendedStatisticsBuilder.ToString());
    }

    public TimeSpan GetAverageTrainingTime()
    {
        double totalSeconds = _sessionResults.Sum(r => (r.EndTime - r.StartTime).TotalSeconds);
        return TimeSpan.FromSeconds(totalSeconds / _sessionResults.Count);
    }

    public double GetBestAccuracy() => _sessionResults.Max(r => r.IsAdvancedStrategy ? (double)r.CorrectChars / r.TotalChars * 100 : r.AccuracyPercentage);

    public double GetWorstAccuracy() => _sessionResults.Min(r => r.IsAdvancedStrategy ? (double)r.CorrectChars / r.TotalChars * 100 : r.AccuracyPercentage);

    public int GetTotalTrainingSessions() => _sessionResults.Count;
}
