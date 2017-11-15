using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ConsoleUI.Subscribers
{
    class TimeIntervalDemonstrator
    {
        private static int numOfInstances = 0;
        private int num;

        public TimeIntervalDemonstrator() => num = ++numOfInstances;

        private void ShowTimeInterval(object obj, TimeOutEventArgs eventArgs)
        {
            Console.WriteLine($"TimeIntervalDemonastrator {num}: time of start - {eventArgs.StartTime}, time of end - {eventArgs.EndTime}");
        }

        public void Register(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException("timer can't be null");

            timer.TimeOut += ShowTimeInterval;
        }

        public void Unregister(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException("timer can't be null");

            timer.TimeOut -= ShowTimeInterval;
        }
    }
}
