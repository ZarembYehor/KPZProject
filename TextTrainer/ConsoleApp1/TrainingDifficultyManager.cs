using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    public class TrainingDifficultyManager
    {
        public int GetWordCountForDifficulty(DifficultyLevel difficulty)
        {
            switch (difficulty)
            {
                case DifficultyLevel.Easy:
                    return 3;
                case DifficultyLevel.Medium:
                    return 5;
                case DifficultyLevel.Hard:
                    return 10;
                default:
                    throw new ArgumentException("Invalid training difficulty.");
            }
        }
    }
}
