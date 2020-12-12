using System;

namespace Logic.Models
{
    public class WayPoint
    {
        public int XPos { get; set; }

        public int YPos { get; set; }

        public void RotateAroundPoint(int pivotX, int pivotY, int angle)
        {
            double sin = Math.Sin(angle * 0.01745);
            double cos = Math.Cos(angle * 0.01745);

            // Translate back to origin
            XPos -= pivotX;
            YPos -= pivotY;

            // Rotate point
            int xnew = Convert.ToInt32(XPos * cos - YPos * sin);
            int  ynew = Convert.ToInt32(XPos * sin + YPos * cos);

            // Translate point back
            XPos = xnew + pivotX;
            YPos = ynew + pivotY;
        }
    }
}
