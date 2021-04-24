using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using static Utils;

namespace AdventOfCode
{
    class Day2
    {
        static void FakeMain(string[] args)
        {
            int validpasswords = 0;
            foreach (string line in File.ReadAllLines(AOCPath))
            {
                string formattedLine = Regex.Replace(line, @"[:]", "");
                string[] sections = formattedLine.Split(' ');
                string[] range = sections[0].Split('-');

                bool valid = sections[2][int.Parse(range[0]) - 1] == sections[1][0] ^ sections[2][int.Parse(range[1]) - 1] == sections[1][0];

                if (valid)//(count >= int.Parse(range[0]) && count <= int.Parse(range[1]))
                {
                    validpasswords++;
                }
            }
            Console.WriteLine(validpasswords);
        }
    }
}
