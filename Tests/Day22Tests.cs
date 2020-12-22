using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class Day22Tests
    {
        private List<int> p1 = new List<int>() { 26, 16, 33, 8, 5, 46, 12, 47, 39, 27, 50, 10, 34, 20, 23, 11, 43, 14, 18, 1, 48, 28, 31, 38, 41 };
        private List<int> p2 = new List<int>() { 45, 7, 9, 4, 15, 19, 49, 3, 36, 25, 24, 2, 21, 37, 35, 44, 29, 13, 32, 22, 17, 30, 42, 40, 6 };

        [TestMethod]
        public void Day22Part1Test()
        {
            var day22 = new Day22();

            var actual = day22.Part1(p1, p2);
            var expected = 31957;   

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day22Part1ExampleTest()
        {
            var day22 = new Day22();

            var actual = day22.Part1(new List<int>() { 9, 2, 6, 3, 1 }, new List<int>() { 5, 8, 4, 7, 10 });
            var expected = 306; 

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day22Part2ExampleTest()
        {
            var day22 = new Day22();

            var actual = day22.Part2(new List<int>() { 9, 2, 6, 3, 1 }, new List<int>() { 5, 8, 4, 7, 10 });
            var expected = 291;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day22Part2Test()
        {
            var day22 = new Day22();

            var actual = day22.Part2(p1, p2);
            var expected = 33212;

            Assert.AreEqual(expected, actual);
        }
    }
}
