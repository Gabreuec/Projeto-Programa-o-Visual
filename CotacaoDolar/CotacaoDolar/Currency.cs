using Newtonsoft.Json;

namespace CotacaoDolar
{
   public class Currency
    {
            [JsonProperty(PropertyName = "name")]

            public string Name { get; set; }

            [JsonProperty(PropertyName = "buy")]
            public string Buy { get; set; }

            [JsonProperty(PropertyName = "sell")]
            public string Sell { get; set; }

            [JsonProperty(PropertyName = "variation")]
            public string Variation { get; set; }

    }
}
