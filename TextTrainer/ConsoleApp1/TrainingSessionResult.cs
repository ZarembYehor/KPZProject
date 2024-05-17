using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrainingSessionResult
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Accuracy { get; set; }

        public override string ToString()
        {
            return $"Start Time: {StartTime}, End Time: {EndTime}, Accuracy: {Accuracy:F2}%";
        }
    }
}
