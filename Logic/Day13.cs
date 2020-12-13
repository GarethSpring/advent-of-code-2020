using System.Collections.Generic;
using System.Linq;

namespace Logic
{

    public class Day13
    {
        private List<string> busIds;
        private Dictionary<int, int> earliestDepartures = new Dictionary<int, int>();

        public int Part1(int earliestTimestamp, string input)
        {
            busIds = input.Split(',').ToList().Where(x => x.Trim() != "x").ToList();

            foreach (string bus in busIds)
            {
                var id = int.Parse(bus);

                var t = earliestTimestamp;

                while (t % id != 0)
                {
                    t++;
                }

                earliestDepartures.Add(id, t);
            }

            var firstDeparture = earliestDepartures.Min(kvp => kvp.Value);
            var firstDepartureBus = earliestDepartures.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

            var waitTime = firstDeparture - earliestTimestamp;

            return waitTime * firstDepartureBus;
        }

        /// <summary>
        /// Optimus Prime
        /// </summary>
        public long Part2(string input)
        {
            busIds = input.Split(',').ToList().ToList();

            long minTimeStamp = 0;
            var step = long.Parse(busIds[0]);

            foreach (var bus in busIds.Where(b => b.Trim() != "x").Skip(1))
            {
                var nextTime = int.Parse(bus);
                while (true)
                {
                    minTimeStamp += step;

                    // Skip gap of all primes so far and check if it matches criteria (mod zero)
                    if ((minTimeStamp + busIds.IndexOf(bus)) % nextTime == 0)
                    {
                        step *= nextTime;
                        break;
                    }
                }
                
            }

            return minTimeStamp;
        }
    }
}
