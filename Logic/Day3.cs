using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{
    public class Day3
    {
        private Dictionary<(int, int), char> grid;
        private int slopeLength;
        private int slopeWidth;

        public long Part1()
        {
            ReadInput();

            CloneSlope();

            return TraverseAndCount(3, 1);
        }

        public long Part2()
        {
            ReadInput();

            CloneSlope();

            return TraverseAndCount(1, 1) * TraverseAndCount(3, 1) * TraverseAndCount(5, 1) *
                TraverseAndCount(7, 1) * TraverseAndCount(1, 2);
        }

        private long TraverseAndCount(int across, int down)
        {
            int posX = 0;
            int posY = 0;
            bool running = true;
            int treeCount = 0;

            while (running)
            {
                posX += across;
                posY += down;

                char c;
                running = grid.TryGetValue((posX, posY), out c);
                if (c == '#')
                {
                    treeCount++;
                }
            }

            return treeCount;
        }

        private void CloneSlope()
        {
            var repetitions= 100;

            for (int i = 1; i <= repetitions; i++)
            {
                for (int x = 0; x < slopeWidth; x++)
                {
                    for (int y = 0; y < slopeLength; y++)
                    {
                        grid.Add(((slopeWidth * i) + x, y), grid[(x,y)]);
                    }
                }
            }
        }

        private void ReadInput()
        {
            grid = new Dictionary<(int, int), char>();

            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input3.txt");

            int y = 0;

            foreach (var line in input)
            {
                int x = 0;

                foreach (char c in line.ToCharArray())
                {
                    grid.Add((x, y), c);
                    x++;
                    slopeWidth = x;
                }

                y++;
            }

            slopeLength = y;
        }
    }
}
