using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day15Tests
    {
        [TestMethod]
        public void Day15Part1TestExample1()
        {
            var day15 = new Day15();

            var actual = day15.Part1("0,3,6", 10);
            var expected = "0";

            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void Day15Part1TestExample2()
        {
            var day15 = new Day15();

            var actual = day15.Part2("1,3,2", 2020);
            var expected = "1";

            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void Day15Part1()
        {
            var day15 = new Day15();

            var actual = day15.Part1("13,16,0,12,15,1", 2020);
            var expected = "319";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day15Part2()
        {
            var day15 = new Day15();

            var actual = day15.Part2("13,16,0,12,15,1", 30000000);
            var expected = "2424";

            Assert.AreEqual(expected, actual);
        }
    }
}
