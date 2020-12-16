using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Tests
{
    [TestClass]
    public class Day16Tests
    {
        [TestMethod]
        public void Day16Part1Test()
        {
            var day16 = new Day16();

            var actual = day16.Part1();
            var expected = 25972;

            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void Day16Part2Test()
        {
            var day16 = new Day16();

            var actual = day16.Part2("83,127,131,137,113,73,139,101,67,53,107,103,59,149,109,61,79,71,97,89");
            var expected = 622670335901; 

            Assert.AreEqual(expected, actual);
        }
    }
}
