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
        #region Public methods

        #region Methods with comparer
        /// <summary>
        /// Finds inex of first element <paramref name="value"/> in array 
        /// between <paramref name="fromIdx"/> and <paramref name="toIdx"/>.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="array">Array.</param>
        /// <param name="value">Value to searh.</param>
        /// <param name="fromIdx">Index of array from which to start the search.</param>
        /// <param name="toIdx">Index of array on which the search ends.</param>
        /// <param name="comparer">Criteria for comparing values of type T</param>
        /// <exception cref="ArgumentNullException">array is null. Or comparer is null 
        /// and type T doesn't realize IComparable interface.</exception>
        /// <exception cref="ArgumentOutOfRangeException">fromIdx or toIdx have invalid values.</exception>
        /// <returns>if element == value was found returns idex of this element; -1, otherwise.</returns>
        public static int BinarySearch<T>(T[] array, T value, int fromIdx, int toIdx, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array of elements must be not null");
            }

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

            if (array.Length == 0)
            {
                return -1;
            }

            if (fromIdx < 0 || toIdx >= array.Length || fromIdx > toIdx)
            {
                throw new ArgumentOutOfRangeException("Indexes must be in range [0; length of the array) and fromIdx <= toIdx");
            }

            if (comparer.Compare(value, array[fromIdx]) < 0
                || comparer.Compare(value, array[toIdx]) > 0)
            {
                return -1;
            }

            return BinarySearchAlgorithm(array, value, fromIdx, toIdx, comparer);
        }

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
        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array of elements must be not null");
            }

            return BinarySearch(array, value, 0, array.Length - 1, comparer);
        }
        #endregion

        /// <summary>
        /// Finds inex of first element <paramref name="value"/> in array.
        /// </summary>
        /// <typeparam name="T">Type of value. Should realize IComparable</typeparam>
        /// <param name="array">Array.</param>
        /// <param name="value">Value to searh.</param>
        /// <exception cref="ArgumentNullException">array is null. Or type T doesn't realize IComparable interface</exception>
        /// <returns>if element == value was found returns idex of this element; -1, otherwise.</returns>
        public static int BinarySearch<T>(T[] array, T value)
        {
            return BinarySearch(array, value, (IComparer<T>)null);
        }

        #region Methods with comparison
        /// <summary>
        /// Finds inex of first element <paramref name="value"/> in array 
        /// between <paramref name="fromIdx"/> and <paramref name="toIdx"/>.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="array">Array.</param>
        /// <param name="value">Value to searh.</param>
        /// <param name="fromIdx">Index of array from which to start the search.</param>
        /// <param name="toIdx">Index of array on which the search ends.</param>
        /// <param name="comparison">Criteria for comparing values of type T</param>
        /// <exception cref="ArgumentNullException">array is null. Or comparison is null 
        /// and type T doesn't realize IComparable interface.</exception>
        /// <exception cref="ArgumentOutOfRangeException">fromIdx or toIdx have invalid values.</exception>
        /// <returns>if element == value was found returns idex of this element; -1, otherwise.</returns>
        public static int BinarySearch<T>(T[] array, T value, int fromIdx, int toIdx, Comparison<T> comparison)
        {
            return BinarySearch(array, value, fromIdx, toIdx, Comparer<T>.Create(comparison));
        }

        /// <summary>
        /// Finds inex of first element value in array.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <param name="array">Array.</param>
        /// <param name="value">Value to searh.</param>
        /// <param name="comparison">Criteria for comparing values of type T</param>
        /// <exception cref="ArgumentNullException">array is null. Or comparison is null 
        /// and type T doesn't realize IComparable interface</exception>
        /// <returns>if element == value was found returns idex of this element; -1, otherwise.</returns>
        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comparison)
        {
            return BinarySearch(array, value, 0, array.Length - 1, Comparer<T>.Create(comparison));
        }
        #endregion
        #endregion

        #region Private methods
        private static int BinarySearchAlgorithm<T>(T[] array, T value, int fromIdx, int toIdx, IComparer<T> comparer)
        {
            int first = fromIdx, last = toIdx;

            while (first < last)
            {
                int mid = first + ((last - first) / 2);
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
        #endregion 
    }
}
