using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HarryPotter
{
    public class Wand
    {

        [JsonProperty("wood")]
        public string wood { get; set; }

        [JsonProperty("core")]
        public string core { get; set; }

        [JsonProperty("length")]
        public object length { get; set; }
    }
}
