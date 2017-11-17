using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Class for timer.
    /// </summary>
    public class CustomTimer
    {
        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="time">Time in seconds.</param>
        public CustomTimer(int time)
        {
            if (time < 0)
            {
                throw new ArgumentOutOfRangeException("Time must be a positive number");
            }

            Time = time;
        }
        #endregion

        #region Properties
        
        /// <summary>
        /// Event for time out.
        /// </summary>
        public event EventHandler<TimeOutEventArgs> TimeOut = delegate { };

        /// <summary>
        /// Time in seconds.
        /// </summary>
        public int Time { get; }
        #endregion

        #region Public methods
        /// <summary>
        /// Starts timer with time interval specified in constructor.
        /// </summary>
        public void Start()
        {
            Start(Time);
        }

        /// <summary>
        /// Starts timer with specified time.
        /// </summary>
        /// <param name="time">Time interval.</param>
        /// <exception cref="ArgumentOutOfRangeException">time less than 0</exception>
        public void Start(int time)
        {
            if (time < 0)
            {
                throw new ArgumentOutOfRangeException("Time must be a positive number");
            }

            Console.WriteLine(1);
            DateTime start = DateTime.Now;
            Thread.Sleep(time * 1000);
            DateTime end = DateTime.Now;
            OnTimeOut(new TimeOutEventArgs(time, start, end));
        }
        #endregion

        #region Protected method
        protected virtual void OnTimeOut(TimeOutEventArgs e)
        {
            EventHandler<TimeOutEventArgs> temp = TimeOut;
            temp?.Invoke(this, e);
        }
        #endregion
    }
}
