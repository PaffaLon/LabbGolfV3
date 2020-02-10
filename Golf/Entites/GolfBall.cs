using System;
using System.Collections.Generic;
using System.Text;

namespace Golf.Entitys
{
    internal class GolfBall
    {

        private double Position { get; set; }
        private double Weight   { get; set; }

        /// <summary>
        /// The distance the ball have traveld from position A to B.
        /// </summary>
        private double TravelDistance { get; set; }

        internal GolfBall()
        {

        }


        /// <summary>
        /// Updates the golfblass curent position.
        /// </summary>
        /// <param name="newPosition"></param>
        public void SetPosition(double newPosition)
        {
            this.Position = newPosition;
        }

        /// <summary>
        /// Resives the golfballs curent position.
        /// </summary>
        /// <returns></returns>
        public double getPosition()
        {
            return this.Position;
        }
        
    }
}
