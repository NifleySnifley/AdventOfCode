using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode
{
    class Day1
    {
        const string AOCPath = "C:\\Users\\finns\\source\\repos\\AdventOfCode\\AdventOfCode";
        static void FakeMain(string[] args)
        {
            List<int> dates = new List<int>();
            foreach (string line in File.ReadAllLines(AOCPath + "\\Data.txt"))
            {
                dates.Add(int.Parse(line));
            }

            foreach (int num in dates)
            {
                foreach (int num2 in dates)
                {
                    foreach (int num3 in dates)
                    {
                        if (num + num2 + num3 == 2020)
                        {
                            Console.WriteLine(num * num2 * num3);
                            return;
                        }
                    }
                }
            }

        }
    }
}
