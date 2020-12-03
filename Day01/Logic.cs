using System;
using System.IO;
using System.Collections.Generic;

namespace Day01
{
    public class Logic
    {
        public int Part1()
        {
            var input = ReadInput();

            foreach (int x in input)
            {
                foreach (int y in input)
                {
                    if ( x + y == 2020)
                    {
                        return x * y;
                    }

                }
            }

            return 0;
        }

        public int Part2()
        {
            var input = ReadInput();

            foreach (int x in input)
            {
                foreach (int y in input)
                {
                    foreach (int z in input)
                    {
                        if (x + y + z == 2020)
                        {
                            return x * y * z;
                        }
                    }

                }
            }

            return 0;
        }

        private List<int> ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "\\Input\\Input1.txt");
            var inputList = new List<int>();

            foreach (var line in input)
            {
                inputList.Add(Convert.ToInt32(line));
            }

            return inputList;
        }
    }
}
