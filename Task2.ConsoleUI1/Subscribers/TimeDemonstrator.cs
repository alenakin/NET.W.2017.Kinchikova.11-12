using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ConsoleUI.Subscribers
{
    class TimeDemonstrator
    {
        private static int numOfInstances = 0;
        private int num;

        public TimeDemonstrator() => num = ++numOfInstances;

        private void ShowSpentTime(object obj, TimeOutEventArgs eventArgs)
        {
            Console.WriteLine($"TimeDemonastrator {num}: {eventArgs.Time} sec spent");
        }

        public void Register(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException("timer can't be null");

            timer.TimeOut += ShowSpentTime;
        }

        public void Unregister(CustomTimer timer)
        {
            if (timer == null)
                throw new ArgumentNullException("timer can't be null");

            timer.TimeOut -= ShowSpentTime;
        }
    }
}
