using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class BoardingPass
    {
        public string Data { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int SeatId { get; set; }
    }
}
