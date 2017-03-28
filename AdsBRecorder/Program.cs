using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAA.ERCD.AdsBRecorder
{
    class Program
    {
        static void Main(string[] args)
        {
            string query = @"http://public-api.adsbexchange.com/VirtualRadar/AircraftList.json";
#if DEBUG
            query = query + @"?lat=49.0097&lng=2.5479&fDstL=0&fDstU=50";
            _outputFolderPath = @"C:\temp\adsb_testdata";
#else
            string fileFullPath = null;
            if (args.Length > 0)
            {
                fileFullPath = @args[0];
                if (!File.Exists(fileFullPath))
                {
                    Console.WriteLine("Invalid file path.");
                    Console.WriteLine("Press any key to quit.");
                    Console.ReadKey();
                    return;
                }

                try
                {
                    Setup(new FileInfo(fileFullPath));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press any key to quit.");
                    Console.ReadKey();
                }

                query = query + "?lat=" + _inputs[0].ToString() + "&lng=" +
                    _inputs[1].ToString() + "&fDstL=0&fDstU=" + _inputs[2].ToString();
            }
#endif
            try
            {
                Recorder recorder = new Recorder(query, _outputFolderPath);
                recorder.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to quit.");
                Console.ReadKey();
            }
        }

        private static void Setup(FileInfo inputFileInfo)
        {
            using (StreamReader sr = inputFileInfo.OpenText())
            {
                try
                {
                    string s = "";
                    for (int i = 0; i < 4; i++)
                    {
                        s = sr.ReadLine();
                        if (String.IsNullOrWhiteSpace(s))
                        {
                            throw new Exception($"Error reading input file {inputFileInfo.Name}");
                        }
                        if (i == 0)
                        {
                            //TODO: add Regex to prevent user from entering rubbish data (forbidden characters...)
                            _outputFolderPath = @s;
                        }
                        _inputs[i] = Convert.ToDouble(s.Split('=')[1].Trim());
                        i++;
                    }
                }
                catch
                {
                    throw new Exception($"An error occured while setting up data from {inputFileInfo.Name}");
                }

            }
        }

        private static string _outputFolderPath;
        private static double[] _inputs = new double[3];
        //private double _lat_ddeg;
        //private double _long_ddeg;
        //private double _maxRadius_km;
    }



}
