using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRadar
{
    /// <summary>
    /// This class holds the 2D Cartesian coordinates of a point 
    /// in unit specified by enum Units
    /// </summary>
    public class Point2D
    {
        public Point2D()
        {
            Units = Enums.Units.Meters;
        }

        public Point2D(double xcoord, double ycoord, Enums.Units units = Enums.Units.Meters)
        {
            XCoord = xcoord;
            YCoord = ycoord;
            Units = units;
        }

        public double XCoord { get; set; }

        public double YCoord { get; set; }

        public Enums.Units Units { get; set; }
    }
}
