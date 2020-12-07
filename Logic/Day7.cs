using Logic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Logic
{
    public class Day7
    {
        private List<BagRule> bagRules = new List<BagRule>();

        private readonly string ruleTarget = "shiny gold";

        public int Part1()
        {
            ReadInput();

            return bagRules.Where(rule => RecurseRules(rule))
                .Count();
        }

        public int Part2()
        {
            ReadInput();

            return GetNestedBagCount(bagRules.Single(b => b.Description == ruleTarget));
        }

        private int GetNestedBagCount(BagRule bag)
        {
            int count = 0;

            foreach (var subBag in bag.Contents)
            {
                count += subBag.Value * GetNestedBagCount(bagRules.Single(b => b.Description == subBag.Key)) + subBag.Value;
            }

            return count;
        }

        private bool RecurseRules(BagRule rule)
        {
            if (rule.Contents.ContainsKey(ruleTarget))
            {
                return true;
            }

            foreach (var containedBag in rule.Contents)
            {
                if (RecurseRules(bagRules.Single(r => r.Description == containedBag.Key)))
                {
                    return true;
                }
            }

            return false;
        }

        private void ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input7.txt");

            foreach (string line in input)
            {
                var rule = new BagRule()
                {
                    Contents = new Dictionary<string, int>(),
                    Description = line.Substring(0, line.IndexOf("contain") - 6)
                };

                string contents = line.Substring(line.IndexOf("contain") + 8);

                while (true)
                {
                    if (contents.Contains("no other bags"))
                    {
                        break;
                    }

                    if (contents.IndexOf(',') == -1)
                    {
                        // last - break after this
                        string match2 = contents.Substring(0, contents.Length -1);
                        rule.Contents.Add(match2.Substring(2, match2.Length - 6).Trim(), Convert.ToInt32(match2.Substring(0, 1)));

                        break;
                    }

                    // I'm not crying, you're crying
                    string match = contents.Substring(0, contents.IndexOf(','));
                    rule.Contents.Add(match.Substring(2, match.Length - 6).Trim(), Convert.ToInt32(match.Substring(0,1)));

                    contents = contents.Substring(contents.IndexOf(',') + 2);
                }

                bagRules.Add(rule);
            }
        }
    }
}