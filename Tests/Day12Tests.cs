using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using Logic.Models;

namespace Tests
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public void Day12Part1Test()
        {
            var day12 = new Day12();

            var actual = day12.Part1();
            var expected = 2280;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day12Part2Test()
        {
            var day12 = new Day12();

            var actual = day12.Part2();
            var expected = 38693;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RotateRTest()
        {
            var ship = new Ship() { Heading = 270 };

            var actual = ship.RotateRight(180);
            var expected = 90;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RotateLTest()
        {
            var ship = new Ship() { Heading = 90 };

            var actual = ship.RotateLeft(270);
            var expected = 180;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RotateWayPointTest()
        {
            var w = new WayPoint() { XPos = 6, YPos =  1 };

            w.RotateAroundPoint(0, 0, -180);

            var actualX = w.XPos;
            var actualY = w.YPos;

            Assert.AreEqual(-6, actualX);
            Assert.AreEqual(-1, actualY);
        }
    }
}
