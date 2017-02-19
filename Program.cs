using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace FlightRadar
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://public-api.adsbexchange.com/VirtualRadar/AircraftList.json?lat=45.7234&lng=5.0888&fDstL=0&fDstU=20
            string connectionString = @"https://public-api.adsbexchange.com/VirtualRadar/AircraftList.json";
            double lat_deg = 51.5005173d; // 45.7234d;
            double long_deg = -0.0360303d; // 5.0888d;
            double northBound_deg = 51.57d;
            double southBound_deg = 51.45d;
            double eastBound_deg = -0.15d;
            double westBound_deg = 0.042d;
            //double searchRadius_km = 10d;

            //string query = connectionString + "?lat=" + lat_deg.ToString() +
            //    "&lng=" + long_deg.ToString() + "&fDstL=0&fDstU=" + searchRadius_km.ToString();
            string query = connectionString + "?fNBnd=" + northBound_deg.ToString() +
                "&fSBnd=" + southBound_deg.ToString() + "&fEBnd=" + eastBound_deg.ToString() +
                "&fWBnd=" + westBound_deg.ToString();

            string ldv = null; //how to initialize this?
            LatLongToGeoConverter converter = new LatLongToGeoConverter(lat_deg, long_deg);

            //string query = @"https://public-api.adsbexchange.com/VirtualRadar/AircraftList.json?lat=45.7234&lng=5.0888&fDstL=0&fDstU=100";
            using (var file = new StreamWriter(@"C:\temp\aircraft.json"))
            {
                int count = 0;
                //Dictionary<string, List<Tuple<double[]>>> aircrafts; 
                while (count< 20)
                {
                    //if (count > 0)
                    //    query += "&lastDv=" + ldv;
                    var json = new WebClient().DownloadString(query);
                    JObject rss = JObject.Parse(json);
                    JArray aircrafts = (JArray)rss["acList"];
                    
                    ldv = (string)rss["lastDv"];

                    //var aircraft = (string)rss["acList"];

                    var aircraft = ((JArray)rss["acList"]).First();
                    string id = (string)aircrafts.First()["Id"];
                    double @lat = (double)aircrafts.First()["Lat"];
                    double @long = (double)aircrafts.First()["Long"];

                    var xy_coords = converter.Convert(@lat, @long);

                    //JavaScriptSerializer oJS = new JavaScriptSerializer();
                    //Aircrafts acfts = new Aircrafts();
                    //acfts = oJS.Deserialize<Aircrafts>(json);

                    file.WriteLine("{0}, {1}, {2}", id, xy_coords.XCoord, xy_coords.YCoord);                    
                    Console.WriteLine("{0}, {1}, {2}", id, xy_coords.XCoord, xy_coords.YCoord);
                    Thread.Sleep(3000);
                    count++;
                }
            }
            //Console.ReadKey();
        }
    }
}
