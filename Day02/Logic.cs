using System;
using System.IO;
using System.Collections.Generic;

namespace Day02
{
    public class Logic
    {
        private List<PolicyPassword> policyPasswordList;

        public int Part1()
        {
            ReadInput();

            int valid = 0;

            foreach (var p in policyPasswordList)
            {
                char[] chars = p.Password.ToCharArray();

                int charCount = 0;
                foreach (char c in chars)
                {
                    if (c.ToString() == p.Letter)
                    {
                        charCount++;
                    }
                }

                if (charCount >= p.Min && charCount <= p.Max)
                {
                    valid++;
                }

            }

            return valid;
        }

        public int Part2()
        {
            ReadInput();

            int valid = 0;

            foreach (var p in policyPasswordList)
            {
                char[] chars = p.Password.ToCharArray();

                if (
                    (chars[p.Min - 1].ToString() == p.Letter.ToString() && chars[p.Max - 1].ToString() != p.Letter.ToString())
                    || (chars[p.Min - 1].ToString() != p.Letter.ToString() && chars[p.Max - 1].ToString() == p.Letter.ToString()))
                {
                    valid++;
                }
            }

            return valid;
        }

        private void ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "\\Input\\Input.txt");
            var inputList = new List<PolicyPassword>();

            foreach (var line in input)
            {
                var p = new PolicyPassword();
        
                p.Min = Convert.ToInt32(line.Substring(0, line.IndexOf('-')));
                var lenTemp = line.IndexOf(' ') - 1 - line.IndexOf('-');
                p.Max = Convert.ToInt32(line.Substring(line.IndexOf('-') + 1, lenTemp));
                lenTemp = line.IndexOf(':') - 1 - line.IndexOf(' ');
                p.Letter = line.Substring(line.IndexOf(' ') + 1, lenTemp);
                p.Password = line.Substring(line.IndexOf(':') + 2);

                inputList.Add(p);
            }

            policyPasswordList = inputList;
        }
    }
}
