using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode
{
    class Day4
    {
        const string AOCPath = "../../../data.txt";
        
        static bool ValidateByr(string input)
        {
            int byr = int.Parse(input);
            return byr >= 1920 && byr <= 2002;
        }
        static bool ValidateHgt(string value)
        {
            if (value.EndsWith("cm"))
            {
                if (int.TryParse(value[0..^2], out var intValue))
                    return intValue >= 150 && intValue <= 193;
            }
            else if (value.EndsWith("in"))
            {
                if (int.TryParse(value[0..^2], out var intValue))
                    return intValue >= 59 && intValue <= 76;
            }

            return false;
        }
        static bool ValidateIyr(string value)
        {
            int iyr = int.Parse(value);
            return iyr >= 2010 && iyr <= 2020;
        }
        static bool ValidateEyr(string value)
        {
            int eyr = int.Parse(value);
            return eyr >= 2020 && eyr <= 2030;
        }
        static bool ValidateHcl(string value)
        {
            return Regex.IsMatch(value, @"^#[a-fA-F0-9]{6}$");
        }
        static bool ValidateEcl(string value)
        {
            return new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value);
        }
        static bool ValidatePid(string value)
        {
            return Regex.IsMatch(value, @"^[0-9]{9}");
        }

        static void Main(string[] args)
        {
            string[] passports = File.ReadAllText(AOCPath).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var reqFields = new Dictionary<string, Func<string, bool>>
            {
                { "byr", ValidateByr },
                { "iyr", ValidateIyr },
                { "eyr", ValidateEyr },
                { "hgt", ValidateHgt },
                { "hcl", ValidateHcl },
                { "ecl", ValidateEcl },
                { "pid", ValidatePid },
            };

            int Part1, Part2;
            Part1 = Part2 = 0;

            foreach (string passport in passports)
            {
                Dictionary<string, string> fields = new Dictionary<string, string>();
                foreach (string pair in passport.Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] rawValues = pair.Split(":");
                    fields.Add(rawValues[0], rawValues[1]);

                    if (reqFields.Keys.All(fieldKey => fields.Keys.Contains(fieldKey)))
                    {
                        Part1++;

                        if (reqFields.All(fieldPair => fieldPair.Value(fields[fieldPair.Key])))
                            Part2++;
                    }
                }
            }
            Console.WriteLine($"Part 1 {Part1.ToString()}");
            Console.WriteLine($"Part 2 {Part2.ToString()}");
        }
    }
}
