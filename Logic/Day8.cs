using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace Logic
{
    public class Day8
    {
        public long Part1()
        {
            var cpu = new Cpu();
            cpu.Inputs = ReadInput();

            return cpu.Run(returnOnLoop: true);
        }

        public long Part2()
        {
            var cpu = new Cpu();
            var inputs = ReadInput();

            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputs[i].Item1 == "jmp")
                {
                    inputs = ReadInput();
                    inputs[i] = ("nop", inputs[i].Item2);
                    cpu.Inputs = inputs;
                    cpu.Reset();

                    if (cpu.Run(returnOnLoop: true) == -1)
                    {
                        // Terminated Normally
                        return cpu.Acc;
                    }
                    
                }
            }

            return 0;
        }

        private List<(string, long)> ReadInput()
        {
            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input8.txt");

            var program = new List<(string, long)>();

            foreach (var line in input)
            {
                program.Add((line.Substring(0,3), Convert.ToInt64(line.Substring(4))));
            }

            return program;
        }
    }
}
