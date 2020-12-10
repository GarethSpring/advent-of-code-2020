using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void Day10Part1Test()
        {
            var day10 = new Day10();

            var actual = day10.Part1();
            var expected = 1820;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day10Part2Test()
        {
            var day10 = new Day10();

            var actual = day10.Part2();
            var expected = 3454189699072;

            Assert.AreEqual(expected, actual);
        }
    }
}
