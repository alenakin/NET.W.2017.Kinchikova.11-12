using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Class for search algorithms
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Finds inex of first element value in array.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="array">Array.</param>
        /// <param name="value">Value to searh.</param>
        /// <param name="comparer">Criteria for comparing values of type T</param>
        /// <exception cref="ArgumentNullException">array is null. Or comparer is null 
        /// and type T doesn't realize IComparable interface</exception>
        /// <returns>if element == value was found returns idex of this element; -1, otherwise.</returns>
        public static int BinarySearch<T> (T[] array, T value, IComparer<T> comparer)
        {
            if (array == null)
                throw new ArgumentNullException("Array of elements must be not null");

            if (comparer == null)
            {
                if (typeof(T).GetInterface("IComparable`1") != null || typeof(T).GetInterface("IComparable") != null)
                {
                    comparer = Comparer<T>.Default;
                }
                else
                {
                    throw new ArgumentNullException("Comparer must be specified for types without IComparable");
                }
            }

            if (array.Length == 0 || comparer.Compare(value, array[0]) < 0
                || comparer.Compare(value, array[array.Length - 1]) > 0)
            {
                return -1;
            }
            
            int first = 0, last = array.Length;
            
            while (first < last)
            {
                int mid = first + (last - first) / 2;
                if (comparer.Compare(value, array[mid]) <= 0)
                {
                    last = mid;
                }
                else
                {
                    first = mid + 1;
                }
            }

            if (comparer.Compare(array[last], value) == 0)
            {
                return last;
            }

            return -1;
        }

        /// <summary>
        /// Finds inex of first element value in array.
        /// </summary>
        /// <typeparam name="T">Type of value. Should realize IComparable</typeparam>
        /// <param name="array">Array.</param>
        /// <param name="value">Value to searh.</param>
        /// <exception cref="ArgumentNullException">array is null. Or type T doesn't realize IComparable interface</exception>
        /// <returns>if element == value was found returns idex of this element; -1, otherwise.</returns>
        public static int BinarySearch<T> (T[] array, T value)
        {
            return BinarySearch(array, value, null);
        }
    }
}
