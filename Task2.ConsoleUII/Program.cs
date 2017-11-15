using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.ConsoleUII.Subscribers;

namespace Task2.ConsoleUII
{
    public class Program
    {
        public static void Main()
        {
            var timer = new CustomTimer(10);
            var demonstrator1 = new TimeDemonstrator();
            var demonstrator2 = new TimeIntervalDemonstrator();

            demonstrator1.Register(timer);
            demonstrator2.Register(timer);

            timer.Start();
        }
    }
}
