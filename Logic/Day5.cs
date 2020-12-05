using Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logic
{
    public class Day5
    {
        private List<BoardingPass> passes = new List<BoardingPass>();

        public int Part1()
        {
            ReadInput();

            DecodePasses();

            return passes.Max(p => p.SeatId);
        }

        public int Part2()
        {
            ReadInput();

            DecodePasses();

            for (int r = passes.Min(p => p.Row) ; r < passes.Max(p => p.Row); r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (!passes.Exists(p => p.Row == r && p.Column == c))
                    {
                        return r * 8 + c;
                    }
                }
            }

            return -1;
        }

        private void DecodePasses()
        {
            foreach (var pass in passes)
            {
                var chars = pass.Data.ToCharArray();

                pass.Row = ParseRow(chars, 0, 127);
                pass.Column = ParseColumn(chars, 0, 7);
                pass.SeatId = pass.Row * 8 + pass.Column;
            }
        }

        private int ParseRow(char[] data, int minRange, int maxRange)
        {
            // Calc Row
            for (int i = 0; i < 7; i++)
            {
                // Lower
                if (data[i] == 'F')
                {
                    maxRange = ((maxRange + 1 - minRange) / 2) - 1 + minRange;
                }

                if (data[i] == 'B')
                {
                    minRange = ((maxRange + 1 - minRange) / 2) + minRange;
                }
            }

            return minRange;
        }

        private int ParseColumn(char[] data, int minRange, int maxRange)
        {
            // Calc Row
            for (int i = 7; i < 10; i++)
            {
                // Lower
                if (data[i] == 'L')
                {
                    maxRange = ((maxRange + 1 - minRange) / 2) - 1 + minRange;
                }

                if (data[i] == 'R')
                {
                    minRange = ((maxRange + 1 - minRange) / 2) + minRange;
                }
            }

            return minRange;
        }

        private void ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input5.txt");

            foreach (var line in input)
            {
                var pass = new BoardingPass { Data = line };
                passes.Add(pass);
            }
        }
    }
}
