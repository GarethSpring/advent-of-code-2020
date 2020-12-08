using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Helpers
{
    public class Cpu
    {
        public List<(string, long)> Inputs { get; set; }

        public long Acc { get; set; }

        public int OpPointer { get; set; }

        public bool Running { get; set; }


        public long Run(bool returnOnLoop)
        {
            Running = true;

            var usedCodes = new List<int>();

            while (Running)
            {
                if (OpPointer > Inputs.Count() -1)
                {
                    // End
                    Running = false;
                    return -1;
                }

                if (returnOnLoop)
                {
                    usedCodes.Add(OpPointer);
                    if (usedCodes.GroupBy(x => x)
                                 .Where(g => g.Count() > 1)
                                 .Select(g => g.Key).Any())
                    {
                        return Acc;
                    }
                }

                switch (Inputs[OpPointer].Item1)
                {
                    case "nop":
                        OpPointer++;
                        break;

                    case "acc":
                        Acc += Inputs[OpPointer].Item2;
                        OpPointer++;
                        break;

                    case "jmp":
                        OpPointer += Convert.ToInt32(Inputs[OpPointer].Item2);
                        break;

                    default:
                        throw new Exception("Invalid op code");
                }
            }

            return -2;
        }
        public void Reset()
        {
            Acc = 0;
            OpPointer = 0;
        }
    }
}
