using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Logic
{
    public class Day16
    {
        private List<(int, int, string)> ranges = new List<(int, int, string)>();
        private List<List<int>> tickets = new List<List<int>>();
        private List<int> invalidValues = new List<int>();

        public int Part1()
        {
            ReadInput();

            foreach (var list in tickets)
            {
                foreach (var i in list)
                {
                    if (!CheckInARange(i))
                    {
                        invalidValues.Add(i);
                    }
                }
            }

            return invalidValues.Sum();
        }

        public long Part2(string myTicket)
        {
            ReadInput();

            var myTicketVals = myTicket.Split(',').Select(Int32.Parse).ToList();

            for (int l = 0; l < tickets.Count; l ++)
            {
                for (int i = 0; i < tickets[l].Count; i++)
                {
                    if (!CheckInARange(tickets[l][i]))
                    {
                        tickets.Remove(tickets[l]);
                    }
                }
            }
            var keyList = new List<(string, int)>();

            var structure = ranges.GroupBy(x => x.Item3).ToList();

            // Loop through each position and match the fields
            for (int col = 0; col < tickets[0].Count; col++) // 20
            {
                // Build up a list of each ticket's value for the given column
                var ticketPositionColVals = new List<int>();
                for (int i = 0; i < tickets.Count; i++)
                {
                    ticketPositionColVals.Add(tickets[i][col]);
                }

                foreach(var s in structure)
                {
                    var item = s.ToList();
                    // Do all ticket values for this column fit in this structure?
                    if (ticketPositionColVals.All(pos =>
                        (pos >= item[0].Item1 && pos <= item[0].Item2) || (pos >= item[1].Item1 && pos <= item[1].Item2)))
                    {
                        keyList.Add((s.Key, col));
                    }
                }
            }

            // Cycle, extracting entries with only one option
            var result = new List<(string,int)>();

            while (keyList.Any())
            {
                var known = keyList
                    .GroupBy(k => k.Item1)
                    .Select(x => new { c = x.Count(), key = x.Key, data = x.ToList() }).ToList().Where(j => j.c == 1);

                foreach (var h in known)
                {
                    result.Add((h.key, h.data[0].Item2));
                    keyList.RemoveAll(x => x.Item1 == h.key || x.Item2 == h.data[0].Item2);
                }
            }

            long sum = 1;
            foreach (var n in result)
            {
                if (n.Item1.StartsWith("departure"))
                {
                    sum = sum * myTicketVals[n.Item2];
                }
            }

            return sum; 
        }

        private bool CheckInARange(int value)
        {
            foreach (var r in ranges)
            {
                if (value >= r.Item1 && value <= r.Item2)
                {
                    return true;
                }
            }

            return false;
        }

        private void ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input16Fields.txt");

            foreach (var line in input)
            {
                Regex x = new Regex(@"([\w\s]{1,}):\s(\d{1,3})-(\d{1,3})\sor\s(\d{1,3})-(\d{1,3})");
                Match match = x.Match(line);
                if (match.Success)
                {
                    var r1 = (int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), match.Groups[1].Value);
                    var r2 = (int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value), match.Groups[1].Value);

                    ranges.Add(r1);
                    ranges.Add(r2);
                }
            }

            var input2 = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input16Nearby.txt");
            foreach (var line2 in input2)
            {
                tickets.Add(line2.Split(',').Select(Int32.Parse).ToList());
            }
        }
    }
}
