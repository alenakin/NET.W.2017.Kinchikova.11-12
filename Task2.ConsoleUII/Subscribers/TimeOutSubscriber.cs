using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ConsoleUII.Subscribers
{
    /// <summary>
    /// Abstract class for subscribers of time out event;
    /// </summary>
    public abstract class TimeOutSubscriber
    {
        /// <summary>
        /// Registers event.
        /// </summary>
        /// <param name="timer">Timer providing event.</param>
        public abstract void Register(CustomTimer timer);

        /// <summary>
        /// Unsubscribers event.
        /// </summary>
        /// <param name="timer">Timer providing event</param>
        public abstract void Unregister(CustomTimer timer);

        protected abstract void HandleTimeOutEvent(object obj, TimeOutEventArgs eventArgs);
    }
}
