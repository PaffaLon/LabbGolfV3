using System;
using System.Collections.Generic;
using System.Text;

namespace Golf.Levels
{
    abstract class Level
    {
        protected double MapLength              { get; set; }
        protected double GolfBallStartPosition  { get; set; }
        protected double GolfHolePositionStart  { get; set; }
        protected double DistanceBetween        { get; set; }
        protected double Gravity { get; } = (9.80);
        protected double[,] Dimension { get; set; }
    }
}
