using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public void Day05Part1Test()
        {
            var day5 = new Day5();

            var actual = day5.Part1();
            var expected = 922;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day05Part2Test()
        {
            var day5 = new Day5();

            var actual = day5.Part2();
            var expected = 747;

            Assert.AreEqual(expected, actual);
        }
    }
}
