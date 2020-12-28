using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day25Tests
    {
        [TestMethod]
        public void Day25Part1TestExample()
        {
            var day25 = new Day25();

            var actual = day25.Part1(5764801, 17807724);
            var expected = 14897079;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day25Part1Test()
        {
            var day25 = new Day25();

            var actual = day25.Part1(10441485, 1004920);
            var expected = 17032383; 

            Assert.AreEqual(expected, actual);
        }
    }
}
