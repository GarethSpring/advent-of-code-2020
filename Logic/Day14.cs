using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Logic
{
    public class Day14
    {
        private char[] maskString = Enumerable.Repeat('X', 34).ToArray();
        ulong mask = 0;
        private Dictionary<long, long> memory = new Dictionary<long, long>();

        public long Part1()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input14.txt");

            string maskLine = string.Empty;

            foreach (var line in input)
            {
                if (line.Substring(0,4) == "mask")
                {
                    maskLine = line.Substring(7);
                }
                else if (line.Substring(0,3) == "mem")
                {
                    var address = long.Parse(line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - line.IndexOf('[') - 1));
                    var value = long.Parse(line.Substring(line.IndexOf('=') + 2));
                    value = Process(maskLine, value);
                    memory[address] = value;
                }
                else
                {
                    throw new Exception("Invalid input");
                }

            }

            return memory.Values.Sum();
        }

        private long Process(string input, long value)
        {
            long bit = 1;
            for (int i = input.Length; i > 0; i--)
            {
                if (input[i-1] != 'X')
                {
                    if (input[i-1] == '0')
                    {
                        // AND
                        value = value &~ bit;
                    }
                    else if (input[i-1] == '1')
                    {
                        // OR
                        value = value | bit;
                    }
                }

                bit = bit * 2;
            }

            return value;
        }
    }
}
