using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Logic;
namespace Tests
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void Day11Part1Test()
        {
            var day11 = new Day11();

            var actual = day11.Part1();
            var expected = 2204;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day11Part2Test()
        {
            var day11 = new Day11();

            var actual = day11.Part2();
            var expected = 1986;

            Assert.AreEqual(expected, actual);
        }
    }
}
