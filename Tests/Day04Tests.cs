using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void Day04Part1Test()
        {
            var day4 = new Day4();

            var actual = day4.Part1();
            var expected = 213;
  
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day04Part2Test()
        {
            var day4 = new Day4();

            var actual = day4.Part2(); 
            var expected = 147; 

            Assert.AreEqual(expected, actual);
        }
    }
}
