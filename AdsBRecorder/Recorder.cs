using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace CAA.ERCD.AdsBRecorder
{
    public class Recorder
    {
        public Recorder(string query, string outputPath)
        {
            bool result = Uri.TryCreate(query, UriKind.Absolute, out _uri)
                && (_uri.Scheme == Uri.UriSchemeHttp || _uri.Scheme == Uri.UriSchemeHttps);
            if (!result)
            {
                throw new Exception("Invalid URL.");
            }

            _client = new WebClient();

            _outputPath = outputPath;
            DirectoryInfo info;
            try
            {
                info = Directory.CreateDirectory(outputPath);
            } 
            catch
            {
                throw new Exception($"Could not create specified output files folder {outputPath}");
            }

            if (info.Exists)
            {
                //throw new Exception($"Could not create {outputPath} because it already exists.");
            }
        }

        public void Start()
        {
            //TODO: verify validity of query
            //TODO: change naming convention of file name
            //TODO: see if DownloadStringAsync improves

            int count = 0;
            string dateTime = DateTime.Today.ToString("d").Replace('/', '-');
            string path = $@"{_outputPath}\{dateTime}-";
            string fullPath = " ";

            while (count < 901) //21601) //86,400 secs every 4secs
            {
                //var json = new WebClient().DownloadString(_query);
                fullPath = path + count.ToString() + ".json";
                var res = _client.DownloadString(_uri);
                
                System.IO.File.WriteAllText(fullPath, res);
                Console.WriteLine("{0}", count);
                Thread.Sleep(4000);
                count++;
            }
        }

        private Uri _uri;
        private WebClient _client;
        private string _outputPath;
    }
}
