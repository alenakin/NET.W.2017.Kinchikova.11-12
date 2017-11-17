using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task4.SequanceCounter;

namespace Task4.Tests
{
    [TestFixture]
    public class SequanceCounterTests
    {
        [Test]
        public void FibonacciNumbers_Check()
        {
            int n = 20;
            foreach (BigInteger i in FibonacciNumbers(n))
            {
                Console.Write(i + " ");
            }
        }
    }
}
