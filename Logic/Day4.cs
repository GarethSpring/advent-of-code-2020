﻿using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Logic
{
    public class Day4
    {
        private List<Dictionary<string, string>> passports;

        private PassportValidator passportValidator = new PassportValidator();

        public int Part1()
        {
            ReadInput();

            return passportValidator.FirstPassValidation(passports).Count;
        }

        public int Part2()
        {
            ReadInput();

            return passportValidator.FirstPassValidation(passports).Where(p => IsValid(p)).Count();
        }

        private bool IsValid(Dictionary<string,string> passport)
        {
            foreach (string key in passport.Keys)
            {
                if (!passportValidator.KeyValidators[key].Invoke(passport[key]))
                {
                    return false;
                }
            }

            return true;
        }

        private void ReadInput()
        {
            passports = new List<Dictionary<string, string>>();

            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input4.txt");

            var passport = new Dictionary<string, string>();

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (passport.Count > 0)
                    {
                        passports.Add(passport);
                    }

                    passport = new Dictionary<string, string>();
                }
                else
                {
                    Regex x = new Regex(@"(([\S]*):([\S]*))+");
                    Match match = x.Match(line);

                    while (match.Success)
                    {
                        passport.TryAdd(match.Groups[2].Value, match.Groups[3].Value);
                        match = match.NextMatch();
                    }
                }
            }

            passports.Add(passport);
        }
    }
}
