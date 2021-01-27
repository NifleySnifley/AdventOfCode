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
        
        // Validation functions (lambda syntax)
        static bool ValidateByr(string input) =>
            input.Length == 4 &&
            int.TryParse(input, out int byr) && 
            byr >= 1920 && byr <= 2002;
 
        static bool ValidateHgt(string value)
        {
            if (value.EndsWith("cm"))
            {
                if (int.TryParse(value[0..^2], out int intValue))
                    return intValue >= 150 && intValue <= 193;
            }
            else if (value.EndsWith("in"))
            {
                if (int.TryParse(value[0..^2], out int intValue))
                    return intValue >= 59 && intValue <= 76;
            }

            return false;
        }
        static bool ValidateIyr(string value) =>
            value.Length == 4 &&
            int.TryParse(value, out int iyr) &&
            iyr >= 2010 && iyr <= 2020;
        
        static bool ValidateEyr(string value) =>
            value.Length == 4 &&
            int.TryParse(value, out int eyr) &&
            eyr >= 2020 && eyr <= 2030;
        
        static bool ValidateHcl(string value) =>
            Regex.IsMatch(value, "^#[0-9a-f]{6}$");

        static bool ValidateEcl(string value) =>
            new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value);

        static bool ValidatePid(string value) =>
            Regex.IsMatch(value, "^[0-9]{9}$");
        

        static void Main(string[] args)
        {
            // Read all lines
            string[] passports = File.ReadAllLines(AOCPath);
            
            // Dict to store validation functions and related keys
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

            int lineIndex = 0;
            // Keep looping 'til index reaches end of lines read, then break loop
            while (true)
            {
                Dictionary<string, string> fields = new Dictionary<string, string>();

                // Parse oassoirt data into raw key-value pairs and add them into dictionary for current passport
                while (true)
                {
                    string line = passports[lineIndex++];
                    if (string.IsNullOrWhiteSpace(line)) break;

                    string[] rawFields = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (string rawField in rawFields)
                    {
                        string[] rawKVP = rawField.Split(":");
                        fields.Add(rawKVP[0], rawKVP[1]);
                    }

                    if (lineIndex == passports.Length) break;
                }

                // Use List.All to validate inputs
                if (reqFields.Keys.All(field => fields.Keys.Contains(field)))
                {
                    Part1++;
                    if (reqFields.All(fieldPair => fieldPair.Value(fields[fieldPair.Key]))) Part2++;
                }

                if (lineIndex == passports.Length) break;
            }

            // Write output to the console DUH
            Console.WriteLine($"Part 1 {Part1.ToString()}");
            Console.WriteLine($"Part 2 {Part2.ToString()}");
        }
    }
}
