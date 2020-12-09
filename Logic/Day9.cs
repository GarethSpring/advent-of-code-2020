using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Logic
{
    public class Day9
    {
        private int preambleLength = 25;
        private List<long> preamble;
        private Queue<long> sequence;

        private long current;

        public long Part1()
        {
            ReadInput(true);

            while (sequence.Count != 0)
            {
                if(!FindSum())
                {
                    return current;
                }
            }

            return -1;
        }

        public long Part2()
        {
            var invalidNum = Part1();

            ReadInput(false);

            var range = GetRange(invalidNum);
            return range.Min() + range.Max();
        }

        private List<long> GetRange(long invalidNum)
        {
            var range = new List<long>();

            for (int i = 0; i < sequence.Count; i++)
            {
                var current = sequence.Dequeue();

                if (!range.Any())
                {
                    range.Add(current);
                    continue;
                }

                if (range.Sum() < invalidNum)
                {
                    range.Add(current);
                }

                if (range.Sum() == invalidNum && range.Count >= 2)
                {
                    return range;
                }

                while (range.Sum() > invalidNum)
                {
                    range.RemoveAt(0);
                }
            }

            return range;
        }

        private bool FindSum()
        {
            current = sequence.Dequeue();

            for (int a = 0; a < preambleLength; a++)
            {
                for (int b = 0; b < preambleLength; b++)
                {
                    if (b != a)
                    {
                        if (preamble[a] + preamble[b] == current)
                        {
                            preamble.RemoveAt(0);
                            preamble.Add(current);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void ReadInput(bool withPreamble)
        {
            sequence = new Queue<long>();
            preamble = new List<long>();

            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input9.txt");

            int i = 0;

            foreach (var line in input)
            {
                var value = long.Parse(line);
                if (withPreamble && i < preambleLength)
                {
                    preamble.Add(value);
                    i++;
                    continue;
                }

                sequence.Enqueue(value);
            }
        }
    }
}
