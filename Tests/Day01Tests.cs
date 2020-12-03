using Day01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void Day01Part1Test()
        {
            var day1 = new Logic();

            var actual = day1.Part1();
            var expected = 290784;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day01Part2Test()
        {
            var day1 = new Logic();

            var actual = day1.Part2();
            var expected = 177337980;

            Assert.AreEqual(expected, actual);

        }
    }
}
