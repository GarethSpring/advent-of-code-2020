using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public void Day14Part1Test()
        {
            var day14 = new Day14();

            var actual = day14.Part1();
            var expected = 11179633149677;

            Assert.AreEqual(expected, actual); // 85732624109 too low
        }

    }
}
