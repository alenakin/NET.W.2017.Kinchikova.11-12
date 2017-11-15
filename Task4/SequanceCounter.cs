using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Class which provides method for calculating Fibonacci numbers.
    /// </summary>
    public class SequanceCounter
    {
        /// <summary>
        /// Calculates sequance of n Fibonacci numbers.
        /// </summary>
        /// <param name="n">Number of elements in sequance.</param>
        /// <returns>Sequance of Fibonacci numbers.</returns>
        public static IEnumerable<int> FibonacciNumbers(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n must be greater than zero");

            int x = 1, y = 0;
            yield return 1;
            for (int i = 1; i < n; i++)
            {
                x += y;
                y = x - y;
                yield return x;
            }
        }
    }
}
