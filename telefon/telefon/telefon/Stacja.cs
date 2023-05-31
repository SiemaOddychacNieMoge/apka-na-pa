using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace telefon
{
    internal class Stacja
    {
        [JsonProperty("name")]
        public string Nazwa { get; set; }

        [JsonProperty("description")]
        public string Opis { get; set; }

        [JsonProperty("pressure")]
        public float Cisnienie { get; set; }

        [JsonProperty("temp")]
        public float Temperatura { get; set; }

        [JsonProperty("wind")]
        public float Wiatr { get; set; }
    }
}
