using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day03;

namespace Day03Tests
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void Day03Part1Test()
        {
            var day3 = new Logic();

            var actual = day3.Part1();
            var expected = 218;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03Part2Test()
        {
            var day3 = new Logic();

            var actual = day3.Part2();
            var expected = 3847183340;

            Assert.AreEqual(expected, actual);
        }
    }
}
