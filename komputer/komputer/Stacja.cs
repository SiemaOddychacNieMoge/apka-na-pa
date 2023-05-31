using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace komputer
{
    internal class Stacja
    {
        [JsonProperty("name")]
        public string? Nazwa { get; set; }

        [JsonProperty("description")]
        public string? Opis { get; set; }

        [JsonProperty("pressure")]
        public float Cisnienie { get; set; }

        [JsonProperty("temp")]
        public float Temperatura { get; set; }

        [JsonProperty("wind")]
        public float Wiatr { get; set; }
    }
}
