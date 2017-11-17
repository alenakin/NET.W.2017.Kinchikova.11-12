using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ConsoleUII.Subscribers
{
    /// <summary>
    /// Class which provides information about duration of timer.
    /// </summary>
    public class TimeDemonstrator : TimeOutSubscriber
    {
        #region Fields
        private static int numOfInstances = 0;
        private int num;
        #endregion

        #region Public methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public TimeDemonstrator() => this.num = ++numOfInstances;

        /// <summary>
        /// Registers event.
        /// </summary>
        /// <exception cref="ArgumentNullException">timer is null</exception>
        /// <param name="timer">Timer providing event.</param>
        public override void Register(CustomTimer timer)
        {
            if (timer == null)
            {
                throw new ArgumentNullException("timer can't be null");
            }

            timer.TimeOut += this.HandleTimeOutEvent;
        }

        /// <summary>
        /// Unsubscribers event.
        /// </summary>
        /// <exception cref="ArgumentNullException">timer is null</exception>
        /// <param name="timer">Timer providing event</param>
        public override void Unregister(CustomTimer timer)
        {
            if (timer == null)
            {
                throw new ArgumentNullException("timer can't be null");
            }

            timer.TimeOut -= this.HandleTimeOutEvent;
        }
        #endregion

        #region Method which handles an event
        protected override void HandleTimeOutEvent(object obj, TimeOutEventArgs eventArgs)
        {
            Console.WriteLine($"TimeDemonastrator {num}: {eventArgs.Time} sec spent");
        }
        #endregion
    }
}
