using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Class with events args for time out.
    /// </summary>
    public class TimeOutEventArgs : EventArgs
    {
        #region Properties
        /// <summary>
        /// Time spent
        /// </summary>
        public int Time { get; }

        /// <summary>
        /// Time of start.
        /// </summary>
        public DateTime StartTime { get; }

        /// <summary>
        /// End time.
        /// </summary>
        public DateTime EndTime { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="time">Time spent.</param>
        /// <param name="start">Start time.</param>
        /// <param name="end">End time.</param>
        public TimeOutEventArgs(int time, DateTime start, DateTime end)
        {
            Time = time;
            StartTime = start;
            EndTime = end;
        }
        #endregion
    }
}
