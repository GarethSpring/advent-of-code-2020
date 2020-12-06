using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Group
    {
        public List<CustomsResponse> Persons { get; set; }
    }

    public class CustomsResponse
    {
        public char[] YesAnswers { get; set; }
    }
}
