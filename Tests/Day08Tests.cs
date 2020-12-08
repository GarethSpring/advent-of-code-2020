using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace Tests
{

    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public void Day08Part1Test()
        {
            var day8 = new Day8();

            var actual = day8.Part1();
            var expected = 1782;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Day08Part2Test()
        {
            var day8 = new Day8();

            var actual = day8.Part2();
            var expected = 797;

            Assert.AreEqual(expected, actual);
        }
    }
}
