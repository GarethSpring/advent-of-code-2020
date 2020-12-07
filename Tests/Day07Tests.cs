using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod]
        public void Day07Part1Test()
        {
            var day7 = new Day7();

            var actual = day7.Part1();
            var expected = 224;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day07Part2Test()
        {
            var day7 = new Day7();

            var actual = day7.Part2();
            var expected = 1488;

            Assert.AreEqual(expected, actual);
        }
    }
}
