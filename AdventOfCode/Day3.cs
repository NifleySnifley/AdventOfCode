using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;
using static Utils;

namespace Day3
{
    class Program
    {
        static void FakeMain(string[] args)
        {
            List<string> charArray = new List<string>();

            bool[][] booleantrees = (
                from line in File.ReadAllLines(InputPath)
                where !string.IsNullOrWhiteSpace(line)
                select (
                    from @char in line
                    select (@char == '#')).ToArray()
                ).ToArray();

            int width = booleantrees[0].Length;
            int height = booleantrees.Length;

            long GetNumHits(int rightComponent, int downComponent)
            {
                long down, right, hitCount;
                down = right = hitCount = 0;

                while (down < height)
                {
                    if (booleantrees[down][right]) hitCount++;
                    right = (right + rightComponent) % width;
                    down += downComponent;
                }
                return hitCount;
            }

            Console.WriteLine(GetNumHits(1, 1) * GetNumHits(3, 1) * GetNumHits(5, 1) * GetNumHits(7, 1) * GetNumHits(1, 2));


        }
    }
}
