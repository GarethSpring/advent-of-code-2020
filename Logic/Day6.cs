using System;
using System.Collections.Generic;
using System.IO;
using Logic.Models;
using System.Linq;

namespace Logic
{
    public class Day6
    {
        private List<Group> groups = new List<Group>();

        public int Part1()
        {
            ReadInput();

            return GetYesAnswers();
        }

        public int Part2()
        {
            ReadInput();

            return GetYesAnswers2();
        }

        private int GetYesAnswers()
        {
            int yesCount = 0;
          
            foreach (var group in groups)
            {
                var yesses = new List<char>();
                foreach (var response in group.Persons)
                {
                    foreach (char c in response.YesAnswers)
                    {
                        if (!yesses.Contains(c))
                        {
                            yesses.Add(c);
                            yesCount++;
                        }
                    }
                }
            }

            return yesCount;
        }

        private int GetYesAnswers2()
        {
            int yesCount = 0;

            foreach (var group in groups)
            {
                var yesses = group.Persons.Select(r => r.YesAnswers).ToList();

                foreach (char distinctAnswer in group.Persons.SelectMany(p => p.YesAnswers).Distinct())
                {
                    if (yesses.All(x => x.Contains(distinctAnswer)))
                    {
                        yesCount++;
                    }
                }
            }

            return yesCount;
        }

        private void ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input6.txt");

            var group = new Group() { Persons = new List<CustomsResponse>() } ;

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (group.Persons.Count > 0)
                    {
                        groups.Add(group);

                        group = new Group() { Persons = new List<CustomsResponse>() };
                    }
                }
                else
                {
                    group.Persons.Add(new CustomsResponse() { YesAnswers = line.ToCharArray() });
                }
            }

            groups.Add(group);
        }
    }
}
