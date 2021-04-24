using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using static Utils;

namespace AdventOfCode
{
    class Day5
    {
        static Func<int, int, int> TakeLower = (start, end) => (int) Math.Floor(((float) start + (float) end) / 2);
        static Func<int, int, int> TakeUpper = (start, end) => (int) Math.Ceiling(((float) start + (float) end) / 2);

        static void FakeMain(string[] args)
        {
            string[] codes = File.ReadAllLines(AOCPath);
            List<int> seatIDs = new List<int>();

            // For every seat code
            foreach (string code in codes)
            {
                int rowStart = 0;
                int rowEnd = 127;
                // For every character in the code
                foreach (char character in code[0..7])
                {
                    if (character == 'F') rowEnd = TakeLower(rowStart, rowEnd);
                    else if (character == 'B') rowStart = TakeUpper(rowStart, rowEnd);
                }
                int row = rowStart;
                int columnStart = 0;
                int ColumnEnd = 7;
                foreach (char character in code[7..])
                {
                    if (character == 'L') ColumnEnd = TakeLower(columnStart, ColumnEnd);
                    else if (character == 'R') columnStart = TakeUpper(columnStart, ColumnEnd);
                }
                int column = columnStart;
                seatIDs.Add(row * 8 + column);
            }
            int[] sortedSeatIDs = seatIDs.OrderBy(x => x).ToArray();

            Console.WriteLine($"1: {sortedSeatIDs.Max()}");
            for (int i = 1; i < sortedSeatIDs.Length - 1; i++)
            {
                if (sortedSeatIDs[i - 1] != sortedSeatIDs[i] - 1)
                {
                    Console.WriteLine($"Part 2: {sortedSeatIDs[i] - 1}");
                    break;
                }
            }
            
        }
    }
}
