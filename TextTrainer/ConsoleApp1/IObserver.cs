using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IObserver
    {
        void Update(string message);
        void OnNotificationReceived(string notification);
    }
}
