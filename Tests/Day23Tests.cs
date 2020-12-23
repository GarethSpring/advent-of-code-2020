using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Day23Tests
    { 
        private List<int> input = new List<int> { 4, 8, 7, 9, 1, 2, 3, 6, 5 };

        [TestMethod]
        public void Day23Part1Example1Test()
        {
            var day23 = new Day23();

            var actual = day23.Part1(new List<int> { 3, 8, 9, 1, 2, 5, 4, 6, 7 }, 10);
            var expected = 92658374;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day23Part1Example2Test()
        {
            var day23 = new Day23();

            var actual = day23.Part1(new List<int> { 3, 8, 9, 1, 2, 5, 4, 6, 7 }, 100);
            var expected = 67384529;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day23Part1Test()
        {
            var day23 = new Day23();

            var actual = day23.Part1(input, 100);
            var expected = 89573246;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day23Part2Test()
        {
            var day23 = new Day23();

            var actual = day23.Part2(input, 10000000);
            var expected = 2029056128;

            Assert.AreEqual(expected, actual);
        }
    }
}
