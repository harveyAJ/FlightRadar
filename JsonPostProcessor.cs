using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace FlightRadar
{
    public class JsonPostProcessor
    {
        public void Test()
        {
            string path = @"C:\data-subset";

            Dictionary<string, List<string>> filesContent =
                new Dictionary<string, List<string>>();

            var aircrafts = new Dictionary<string, Aircraft>();

            foreach (var file in Directory.GetFiles(path, "*.json", SearchOption.TopDirectoryOnly))
                //.Where(f => f.EndsWith("2017-14-03-6769.json") ||
                //           f.EndsWith("2017-14-03-6810.json")).ToList())
            {
                file.Count();
                string ext = file.Substring(file.Count() - 9);
                string json = File.ReadAllText(file);

                JObject rss = JObject.Parse(json);
                JArray acList = (JArray)rss["acList"];

                foreach (var ac in acList)
                {
                    var id = (string)ac["Id"];

                    if (!aircrafts.ContainsKey(id))
                    {
                        aircrafts.Add(id, new Aircraft
                        {
                            Id = id,
                        });
                    }

                    aircrafts[id].Add(
                        Convert.ToDouble(ac["PosTime"]),
                        Convert.ToDouble(ac["Lat"]),
                        Convert.ToDouble(ac["Long"]));
                }
            }

            //var filePath = "C:\\temp\\res.csv";
            //using (var file = new StreamWriter(filePath))
            //{
            //    foreach (var aircraft in aircrafts)
            //    {
            //        for (int i = 0; i < aircraft.Value.Count; i++)
            //        {
            //            file.WriteLine($"{aircraft.Value.Id}, {aircraft.Value.PosTime[i]}, {aircraft.Value.Lat[i]}, {aircraft.Value.Long[i]}");
            //        }
            //    }
            //}

        }
    }
}
