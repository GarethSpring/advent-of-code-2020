using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void Day13Part1TestExample()
        {
            var day13 = new Day13();

            var actual = day13.Part1(939, "7, 13, x, x, 59, x, 31, 19");
            var expected = 295;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day13Part1TestActual()
        {
            var day13 = new Day13();

            var actual = day13.Part1(1000186, "17, x, x, x, x, x, x, x, x, x, x, 37, x, x, x, x, x, 907, x, x, x, x, x, x, x, x, x, x, x, 19, x, x, x, x, x, x, x, x, x, x, 23, x, x, x, x, x, 29, x, 653, x, x, x, x, x, x, x, x, x, 41, x, x, 13");
            var expected = 104;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day13Part2TestExample()
        {
            var day13 = new Day13();

            var actual = day13.Part2("7, 13, x, x, 59, x, 31, 19");
            var expected = 1068781;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day13Part2Actual()
        {
            var day13 = new Day13();

            var actual = day13.Part2("17, x, x, x, x, x, x, x, x, x, x, 37, x, x, x, x, x, 907, x, x, x, x, x, x, x, x, x, x, x, 19, x, x, x, x, x, x, x, x, x, x, 23, x, x, x, x, x, 29, x, 653, x, x, x, x, x, x, x, x, x, 41, x, x, 13");
            var expected = 842186186521918;

            Assert.AreEqual(expected, actual);
        }
    }
}
