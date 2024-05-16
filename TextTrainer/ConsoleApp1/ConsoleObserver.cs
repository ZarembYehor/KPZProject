using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConsoleObserver : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Observer received message: {message}");
        }
    }
}
