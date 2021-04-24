using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Utils;

namespace AdventOfCode {
    class Day8 {
		static bool ExecuteAssembly(string[] opcodes) {
			// Set accumulator anc split instructions
			int acc = 0;
			List<int> hasran = new List<int>();
			int i = 0;

			while (true) {
				if (hasran.Contains(i)) {
					Console.WriteLine(string.Format("Looping at line {0}, terminated with accumulator {1}", i, acc));
					return false;
				}
				// Has it executed the last instruction?
				if (i == opcodes.Length) { Console.WriteLine(string.Format("Accumulator ended at {0}", acc)); return true; }

				// Get opcode and argument
				string code = opcodes[i];
				string instruction = code.Split(' ').FirstOrDefault();
				int argument = int.Parse(code.Split(' ').LastOrDefault());
				hasran.Add(i);

				// Instructons switch
				switch (instruction) {
					case "acc": {
						acc += argument;
						i++;
						break;
					}
					case "jmp": {
						i += argument;
						break;
					}
					default: {
						i++;
						break;
					};
				}
			}
			return false;
		}

		public static void Main() {
			string[] opcodes = File.ReadAllLines(AOCPath);
			for (int o = 0; o < opcodes.Length; o++) {
				// Copy the opcodes
				string[] copy = new string[opcodes.Length]; opcodes.CopyTo(copy, 0);
				if (copy[o].Split(' ')[0] == "jmp") {
					copy[o] = copy[o].Replace("jmp", "nop");
				} else if (copy[o].Split(' ')[0] == "nop") {
					copy[o] = copy[o].Replace("nop", "jmp");
				}
				if (ExecuteAssembly(copy)) { Console.WriteLine(string.Format("Successfully executed assembly by changing instruction {0}", o)); break; }
			}
			Console.WriteLine("Finished...");
		}
	}
}
