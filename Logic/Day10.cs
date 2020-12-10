using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Logic
{
    public class Day10
    {
        private List<int> jInput;

        public int Part1()
        {
            ReadInput();

            int diff1 = 0;
            int diff3 = 0;

            for (int i = 1; i < jInput.Count; i++)
            {
                int diff = (jInput[i] - jInput[i - 1]);
                if (diff == 1)
                {
                    diff1++;
                }

                if (diff == 3)
                {
                    diff3++;
                }
            }

            return diff1 * diff3;
        }

        public long Part2()
        {
            ReadInput();   

            var result = Part2Calc();

            return result;
        }

        /// <summary>
        /// TIL Memoization
        /// </summary>
        private long Part2Calc()
        {
            int maxDiff = 3;
            var resultCache = new Dictionary<int, long>();
            resultCache[jInput.Count - 1] = 1;

            for (int a = jInput.Count - 2; a >= 0; a--)
            {
                long validCount = 0;

                for (int b = a + 1; b < jInput.Count && jInput[b] - jInput[a] <= maxDiff; b++)
                {
                    validCount += resultCache[b];
                }

                resultCache[a] = validCount;
            }

            return resultCache[0];
        }

        private void ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input10.txt");
            jInput = new List<int>();

            foreach (var line in input)
            {
                jInput.Add(int.Parse(line));
            }

            jInput.Sort();
            jInput.Insert(0, 0); // Socket
            jInput.Add(jInput.Last() + 3); // Device Adapter
        }
    }

    public static class ArrayExtensions
    {
        public static void Fill<T>(this T[] originalArray, T with)
        {
            for (int i = 0; i < originalArray.Length; i++)
            {
                originalArray[i] = with;
            }
        }
    }
}
