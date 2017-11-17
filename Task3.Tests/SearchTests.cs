using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task3.Search;

namespace Task3.Tests
{
    [TestFixture]
    public class SearchTests
    {
        #region Cases
        private static object[] emptyOrSmallArraysCases =
        {
            new object[] { new int[] { 1 }, 1, 0 },
            new object[] { new int[] { 1 }, 2, -1 },
            new object[] { new int[] { }, 1, -1 },
            new object[] { new int[] { 1, 2 }, 2, 1 },
            new object[] { new int[] { 1, 2 }, 3, -1 },
            new object[] { new int[] { 1, 2 }, 1, 0 }
        };

        private static object[] begEndCases =
        {
            new object[] { new int[] { 1, 2, 3, 4 }, 1, 0 },
            new object[] { new int[] { 1, 2, 3, 4 }, 4, 3 }
        };

        private static object[] doubleCases =
        {
            new object[] { new double[] { 1.32, 2.14, 4.17, 20.0 }, 4.16, -1 },
            new object[] { new double[] { 1.32, 2.14, 4.17, 20.0 }, 4.17, 2 },
        };

        private static object[] typesWithoutComparableCases =
        {
            new object[] { new object[] { new int[] { 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 2, 5, 6 } }, new int[] { 1, 2 } }
        };

        private static object[] stringWithSameLengthCases =
        {
            new object[] { new string[] { "a", "aa", "aa", "aaaa", "aaaaaaa" }, "bbbb", 3 }
        };
        #endregion 

        [TestCaseSource("emptyOrSmallArraysCases")]
        public void BinarySearch_EmptyOrSmallArrays_NoExceptionAndEqualToResult(int[] array, int value, int result)
        {
            int r = BinarySearch(array, value);
            Assert.AreEqual(result, r);
        }

        [TestCaseSource("doubleCases")]
        public void BinarySearch_DoubleArrays_EqualToResult(double[] array, double value, int result)
        {
            int r = BinarySearch(array, value);
            Assert.AreEqual(result, r);
        }

        [TestCaseSource("begEndCases")]
        public void BinarySearch_SearchedValueInBeginningOrEnd_EqualToResult(int[] array, int value, int result)
        {
            int r = BinarySearch(array, value);
            Assert.AreEqual(result, r);
        }

        [Test]
        public void BinarySearch_NullReferenceArray_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearch(null, 2));
        }

        [Test]
        public void BinarySearch_TypeWithoutComparableAndComparer_ArgumentNullException()
        {
            var array = new ExampleClass[] { new ExampleClass(1), new ExampleClass(2), new ExampleClass(3) };
            var value = new ExampleClass(2);

            Assert.Throws<ArgumentNullException>(() => BinarySearch(array, value));
        }

        [Test]
        public void BinarySearch_TypeWithoutComparableButWithComparer_WithoutExceptions()
        {
            var array = new ExampleClass[] { new ExampleClass(1), new ExampleClass(2), new ExampleClass(3) };
            var value = new ExampleClass(2);

            int res = 1;
            int r = BinarySearch(array, value, Comparer<ExampleClass>.Create((x, y) => x.X.CompareTo(y.X)));
            Assert.AreEqual(res, r);
        }

        [TestCaseSource("stringWithSameLengthCases")]
        public void BinarySearch_StringsWithComparer_EqualToResult(string[] array, string value, int res)
        {
            int r = BinarySearch(array, value, Comparer<string>.Create((x, y) => x.Length.CompareTo(y.Length)));

            Assert.AreEqual(res, r);
        }

        private class ExampleClass
        {
            public ExampleClass(int x) => X = x;

            public int X { get; }
        }
    }
}
