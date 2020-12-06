using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public void Day06Part1Test()
        {
            var day6 = new Day6();

            var actual = day6.Part1();
            var expected = 6686;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day06Part2Test()
        {
            var day6 = new Day6();

            var actual = day6.Part2();
            var expected = 3476;

            Assert.AreEqual(expected, actual);
        }
    }
}
