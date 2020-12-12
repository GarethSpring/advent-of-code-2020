using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Logic.Models;

namespace Logic
{
    public class Day12
    {
        private List<(char command, int value)> directions;

        private Ship ship = new Ship()
        {
            Heading = 90,
            XPos = 0,
            YPos = 0
        };

        private WayPoint wayPoint = new WayPoint()
        {
            XPos = 10,
            YPos = -1
        };

        public int Part1()
        {
            ReadInput();

            foreach (var dir in directions)
            {
                switch (dir.command)
                {
                    case 'N':
                        ship.YPos -= dir.value;
                        break;
                    case 'S':
                        ship.YPos += dir.value;
                        break;
                    case 'W':
                        ship.XPos -= dir.value;
                        break;
                    case 'E':
                        ship.XPos += dir.value;
                        break;
                    case 'L':
                        ship.RotateLeft(dir.value);
                        break;
                    case 'R':
                        ship.RotateRight(dir.value);
                        break;
                    case 'F':
                        ship.MoveForward(dir.value);
                        break;
                }
            }

            return ship.XPos + ship.YPos;
        }

        public int Part2()
        {
            ReadInput();

            foreach (var dir in directions)
            {
                switch (dir.command)
                {
                    case 'N':
                        wayPoint.YPos -= dir.value;
                        break;
                    case 'S':
                        wayPoint.YPos += dir.value;
                        break;
                    case 'W':
                        wayPoint.XPos -= dir.value;
                        break;
                    case 'E':
                        wayPoint.XPos += dir.value;
                        break;
                    case 'L':
                        wayPoint.RotateAroundPoint( ship.XPos, ship.YPos, -dir.value);
                        break;
                    case 'R':
                        wayPoint.RotateAroundPoint(ship.XPos, ship.YPos, dir.value);
                        break;
                    case 'F':

                        var distanceX = wayPoint.XPos - ship.XPos;
                        var distanceY = wayPoint.YPos - ship.YPos;
                        for (int i = 0; i < dir.value; i++)
                        {
                            ship.XPos += distanceX;
                            ship.YPos += distanceY;
                        }

                        wayPoint.XPos = ship.XPos + distanceX;
                        wayPoint.YPos = ship.YPos + distanceY;
                        break;
                }
            }

            return ship.XPos + ship.YPos;
        }

        private void ReadInput()
        {
            directions = new List<(char, int)>();
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input12.txt");

            foreach (var line in input)
            {
                directions.Add((line[0], int.Parse(line.Substring(1))));
            }
        }
    }
}
