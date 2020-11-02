using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class PlatformModel
    {
        public int Id { get; set; }
       
        [JsonProperty("id")]
        public int PlatformId { get; set; }
       
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
