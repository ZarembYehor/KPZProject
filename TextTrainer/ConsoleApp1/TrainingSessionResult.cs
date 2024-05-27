using System.Text;

namespace ConsoleApp1;

public class TrainingSessionResult
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double AccuracyPercentage { get; set; }
    public int CorrectChars { get; set; }
    public int TotalChars { get; set; }
    public bool IsAdvancedStrategy { get; set; }

    public override string ToString()
    {
        if (IsAdvancedStrategy)
        {
            var sb = new StringBuilder();

            sb.Append("Start Time: ").Append(StartTime)
              .Append(", End Time: ").Append(EndTime)
              .Append(", Correct Chars: ").Append(CorrectChars)
              .Append(", Total Chars: ").Append(TotalChars)
              .Append(", Accuracy: ").Append(((double)CorrectChars / TotalChars * 100).ToString("F2")).Append('%');

            string result = sb.ToString();
            return result;
        }
        else
        {
            var sb = new StringBuilder();

            sb.Append("Start Time: ").Append(StartTime)
              .Append(", End Time: ").Append(EndTime)
              .Append(", Accuracy: ").Append(AccuracyPercentage.ToString("F2")).Append('%');

            string result = sb.ToString();
            return result;
        }
    }
}
