using System;
using System.Collections.Generic;
using System.Text;

namespace Golf.Levels.Lvs
{
    sealed class Toturial : Level
    {
        internal Toturial()
        {
            this.MapLength = (100);
            this.GolfBallStartPosition = (0);
            this.GolfHolePositionStart = (100);
            this.Dimension = new double[1, 1]; 
            //{ { 0.01 } {  } };
        }

        public double GetMapLength()
        {
            return this.MapLength;
        }
        
        public double GetGolfBallStartPosition()
        {
            return this.GolfBallStartPosition;
        }
        
        public double GetGolfHoleStartPosition()
        {
            return this.GolfHolePositionStart;
        }

        public double GetGravity()
        {
            return this.Gravity;
        }

        public double GetDistanceBetween(double distance)
        {
            return distance;
        }
    }
}
