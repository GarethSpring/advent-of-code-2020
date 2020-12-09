using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public void Day09Part1Test()
        {
            var day9 = new Day9();

            var actual = day9.Part1();
            var expected = 22477624;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day09Part2Test()
        {
            var day9 = new Day9();

            var actual = day9.Part2();
            var expected = 2980044;

            Assert.AreEqual(expected, actual);
        }
    }
}
