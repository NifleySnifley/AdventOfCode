using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AdventOfCode
{
    class Day5
    {
        static Func<int, int, int> TakeLower = (start, end) => (int) Math.Floor(((float) start + (float) end) / 2);
        static Func<int, int, int> TakeUpper = (start, end) => (int) Math.Ceiling(((float) start + (float) end) / 2);

        const string AOCPath = "../../../data.txt";

        static void Main(string[] args)
        {
            string[] codes = File.ReadAllLines(AOCPath);
            int seatID = 0;

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
                seatID = Math.Max(row * 8 + column, seatID);
            }
            Console.WriteLine(seatID);
        }
    }
}
