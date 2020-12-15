using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Day15
    {
        private List<string> startingNumbers;
        private List<string> spoken = new List<string>();
        private Dictionary<string, int> lasts = new Dictionary<string, int>();

        public string Part1(string input, int haltOn)
        {
            startingNumbers = input.Split(',').ToList();

            var last = PlaySlow(haltOn);

            return last;
        }

        public string Part2(string input, int haltOn)
        {
            startingNumbers = input.Split(',').ToList();

            var last = PlayFast(haltOn);

            return last;
        }

        private string PlaySlow(int haltOn)
        {
            for (int j = 0; j < startingNumbers.Count; j++)
            {
                spoken.Add(startingNumbers[j]);
            }
        
            for (int i = startingNumbers.Count; i < haltOn; i++)
            {
                var last = spoken[i-1];
                // If that was the first time the number has been spoken, the current player says 0.
                if (spoken.Where(s => s == last).Count() == 1)
                {
                    spoken.Add("0"); 
                }
                else
                {
                    // the current player announces how many turns apart the number is from when it was previously spoken.
                    var allButLast = spoken.Take(i - 1).ToList();

                    var indexOfSecondLast = allButLast.LastIndexOf(last);

                    var diff = spoken.Count - (indexOfSecondLast + 1);
                    spoken.Add(diff.ToString());
                }
            }

            return spoken.Last();
        }

        private string PlayFast(int haltOn)
        {
            string last = "0";

            for (int j = 0; j < startingNumbers.Count; j++)
            {
                lasts.Add(startingNumbers[j], j + 1);
            }

            for (int i = startingNumbers.Count + 1; i < haltOn; i++)
            {
                var next = lasts.ContainsKey(last) ? i - lasts[last] : 0;
                lasts[last] = i;
                last = next.ToString();
            }

            return last.ToString();
        }
    }
}
