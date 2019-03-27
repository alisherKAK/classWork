﻿using Earthquakes.Models;
using Earthquakes.Services;
using Earthquakes.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Earthquakes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            IDownloader downloader = new Downloader(logger);
            IRepository<FeatureCollection> repository = new XMLRepository<FeatureCollection>(logger);

            var data = downloader.DownloadInfo("https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=20");
            var deserializedData = JsonConvert.DeserializeObject<FeatureCollection>(data);
            repository.Add(deserializedData);
        }
    }
}
