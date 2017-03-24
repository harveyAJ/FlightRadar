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

            //string query = @"http://public-api.adsbexchange.com/VirtualRadar/AircraftList.json?lat=51.4775&lng=-0.461389&fDstL=0&fDstU=100";
            string query = @"http://public-api.adsbexchange.com/VirtualRadar/AircraftList.json?lat=49.0097&lng=2.5479&fDstL=0&fDstU=100";

            //This is not used at the moment:
            string ldv = null;

            #region Retrieve data for 24-hrs period 
            int count = 0;
            while (count < 21601) //86,400 secs every 4secs
            {
                var json = new WebClient().DownloadString(query);
                string fullPath = "C:\\data\\cdg\\2017-14-03-" + count.ToString() + ".json";
                System.IO.File.WriteAllText(fullPath, json);
                Console.WriteLine("{0}", count);
                Thread.Sleep(4000);
                count++;
            }
            #endregion

            #region Post-process the data
            //JsonPostProcessor postProcessor = new JsonPostProcessor();
            //postProcessor.Test();
            #endregion

        }
    }
}
