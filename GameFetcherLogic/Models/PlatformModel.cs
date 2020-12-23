using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameFetcherLogic.Models
{
    public class PlatformModel : IPlatformModel
    {

        [JsonProperty("id")]
        public int platformId { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
