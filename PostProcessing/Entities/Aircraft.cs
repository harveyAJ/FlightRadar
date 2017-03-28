using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProcessing.Entities
{
    public class Aircraft
    {
        public Aircraft()
        {
            PosTime = new List<double>();
            Lat = new List<double>();
            Long = new List<double>();
            Count = 0;
        }

        public string Id { get; set; }//        4499955,
        public string Rcvr { get; set; }//          1,
        public string HasSig { get; set; }//            false,
        public string Icao { get; set; }//          "44A9F3",
        public string Bad { get; set; }//         false,
        public string Reg { get; set; }//         "OO-JOS",
        public string FSeen { get; set; }//           "\/Date(148
        public string TSecs { get; set; }//           90,
        public string CMsgs { get; set; }//           11,
        public string Alt { get; set; }//         7800,
        public string GAlt { get; set; }//          8087,
        public string InHg { get; set; }//          30.2066936,
        public string AltT { get; set; }//          0,
        public string Call { get; set; }//          "JAF26M",
        public List<double> Lat { get; private set; }//         45.884941,
        public List<double> Long { get; private set; }//          5.05203,
        public List<double> PosTime { get; private set; }//             148743105

        public List<double> DeltaT { get; private set; }
        public string Mlat { get; set; }//          false,
        public string Tisb { get; set; }//          false,
        public string Spd { get; set; }//         273.4,
        public string Trak { get; set; }//          239.7,
        public string TrkH { get; set; }//          false,
        public string Type { get; set; }//          "B737",
        public string Mdl { get; set; }//         "Boeing 737NG
        public string Man { get; set; }//         "Boeing",
        public string CNum { get; set; }//          "35282",
        public string Op { get; set; }//        "TUI Airlines 
        public string OpIcao { get; set; }//            "JAF",
        public string Sqk { get; set; }//         "4061",
        public string Help { get; set; }//          false,
        public string Vsi { get; set; }//         3264,
        public string VsiT { get; set; }//          0,
        public string Dst { get; set; }//         18.19,
        public string Brng { get; set; }//          351.0,
        public string WTC { get; set; }//         2,
        public string Species { get; set; }//             1,
        public string Engines { get; set; }//             "2",
        public string EngType { get; set; }//             3,
        public string EngMount { get; set; }//              0,
        public string Mil { get; set; }//         false,
        public string Cou { get; set; }//         "Belgium",
        public string HasPic { get; set; }//            false,
        public string Interested { get; set; }//                false,
        public string FlightsCount { get; set; }//                  0,
        public string Gnd { get; set; }//         false,
        public string SpdTyp { get; set; }//            0,
        public string CallSus { get; set; }//             false,
        public string Trt { get; set; }//         2,
        public string Year { get; set; }//          "2008"}],

        public void Add(double posTime_ms, double lat_deg, double long_deg)
        {
            PosTime.Add(posTime_ms);
            Lat.Add(lat_deg);
            Long.Add(long_deg);
            Count++;
        }

        public int Count { get; private set; }
    }
}
