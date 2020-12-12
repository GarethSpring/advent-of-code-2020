using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Ship
    {
        public int XPos { get; set; }

        public int YPos { get; set; }


        public int Heading { get; set; }

        public void MoveForward(int value)
        {
            switch (Heading)
            {
                case 0:
                    YPos -= value;
                    break;
                case 90:
                    XPos += value;
                    break;
                case 180:
                    YPos += value;
                    break;
                case 270:
                    XPos -= value;
                    break;
            }
        }

    
        public int RotateRight(int degrees)
        {
            var tmp = Heading;

            for (int i = 1; i <= degrees; i++)
            {
                tmp++;
                if (tmp >= 360)
                {
                    tmp = 0;
                }
            }

            Heading = tmp;
            return Heading;
        }

        public int RotateLeft(int degrees)
        {
            var tmp = Heading;

            for (int i = 1; i <= degrees; i++)
            {
                tmp--;
                if (tmp < 0)
                {
                    tmp = 359;
                }
            }

            Heading = tmp;
            return Heading;
        }
    }
}
