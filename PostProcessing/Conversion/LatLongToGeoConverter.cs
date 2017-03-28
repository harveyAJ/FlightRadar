using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostProcessing.Constants;

namespace PostProcessing.Conversion
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

        public double[] Convert(double @lat, double @long)
        {
            return new double[]
            {
                (@long - _long_ref_deg) * PostProcessing.Constants.Constants.EarthRadius_km *
                    Math.Cos(@lat * UnitConverter.DegreesToRadians) * UnitConverter.DegreesToRadians,
                (@lat - _lat_ref_deg) * UnitConverter.DegreesToRadians * PostProcessing.Constants.Constants.EarthRadius_km,
                //Units = Enums.Units.Kilometers
            };
        }
    }
}
