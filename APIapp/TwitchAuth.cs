using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class TwitchAuth
    {
        [JsonProperty("access_token")]
        public string token { get; set; }
       

        public TwitchAuth(string id)
        {
            token = id;
        }
    }

    
}
