using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Logic.Helpers
{ 
    public class PassportValidator
    {
        public  Dictionary<string, Func<string, bool>> KeyValidators { get; set; }
 
        public PassportValidator()
        {
            KeyValidators = new Dictionary<string, Func<string, bool>>
            {
                { "byr", ValidateByr },
                { "iyr", ValidateIyr },
                { "eyr", ValidateEyr },
                { "hgt", ValidateHgt },
                { "hcl", ValidateHcl },
                { "ecl", ValidateEcl },
                { "pid", ValidatePid },
                { "cid", value => true }
            };
        }

        /// <summary>
        /// Validates supplied list of passports, returning only those valid
        /// </summary>
        /// <param name="passports">Passports to validate</param>
        /// <returns>List of valid passports</returns>
        public List<Dictionary<string, string>> FirstPassValidation(List<Dictionary<string, string>> passports)
        {
            var validPassports = new List<Dictionary<string, string>>();

            foreach (var passport in passports)
            {
                bool valid = true;
       
                foreach (string key in KeyValidators.Keys)
                {
                    if (!passport.ContainsKey(key) && key != "cid")
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    validPassports.Add(passport);
                }
            }

            return validPassports;
        }

        private bool ValidateByr(string value)
        {
            var byr = Convert.ToInt32(value);

            return byr >= 1920 && byr <= 2002 ? true : false;
        }

        private bool ValidateIyr(string value)
        {
            var iyr = Convert.ToInt32(value);

            return iyr >= 2010 && iyr <= 2020 ? true : false;
        }

        private bool ValidateEyr(string value)
        {
            var eyr = Convert.ToInt32(value);

            return eyr >= 2020 && eyr <= 2030 ? true : false;
        }

        private bool ValidateHgt(string value)
        {
            Regex r = new Regex(@"([0-9]{2,3})(in|cm)");
            Match match = r.Match(value);
            if (match.Groups[2].Value == "cm")
            {
                var cm = Convert.ToInt32(match.Groups[1].Value);
                if (!(cm >= 150 && cm <= 193))
                {
                    return false;
                }
            }
            else if (match.Groups[2].Value == "in")
            {
                var inches = Convert.ToInt32(match.Groups[1].Value);
                if (!(inches >= 59 && inches <= 76))
                {
                    return false;
                }
            }
            else return false;

            return true;
        }

        private bool ValidateHcl(string value)
        {
            Regex r = new Regex(@"#[0-9a-f]{6}\b");
            Match match2 = r.Match(value);

            return match2.Success ? true : false;
        }

        private bool ValidateEcl(string value)
        {
            List<string> eyeColours = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            foreach (string colour in eyeColours)
            {
                if (colour == value)
                {
                    return true;
                }
            }

            return false;
        }

        private bool ValidatePid(string value)
        {
            Regex z = new Regex(@"^[0-9]{9}\b");
            Match match3 = z.Match(value);

            return match3.Success ? true : false;
        }
    }
}
