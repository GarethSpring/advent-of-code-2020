using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public void Day02Part1Test()
        {
            var day2 = new Day2();

            var actual = day2.Part1();
            var expected = 456;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02Part2Test()
        {
            var day2 = new Day2();

            var actual = day2.Part2();
            var expected = 308;

            Assert.AreEqual(expected, actual);
        }
    }
}
