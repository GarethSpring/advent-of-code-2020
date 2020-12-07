using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class BagRule
    {
        public string Description { get; set; }

        public Dictionary<string, int> Contents { get; set; }
    }
}
