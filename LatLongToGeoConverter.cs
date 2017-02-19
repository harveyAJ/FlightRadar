using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRadar
{
    public class LatLongToGeoConverter
    {
        private double _lat_ref_deg;
        private double _long_ref_deg;

        public LatLongToGeoConverter(double lat_ref_deg, double long_ref_deg)
        {
            _lat_ref_deg = @lat_ref_deg;
            _long_ref_deg = @long_ref_deg;
        }

        public Point2D Convert(double @lat, double @long)
        {
            return new Point2D
            {
                XCoord = (@long - _long_ref_deg) * Constants.EarthRadius_km * 
                    Math.Cos(@lat * Conversion.DegreesToRadians) * Conversion.DegreesToRadians,
                YCoord = (@lat - _lat_ref_deg) * Conversion.DegreesToRadians * Constants.EarthRadius_km,
                Units = Enums.Units.Kilometers
            };
        }
    }
}
