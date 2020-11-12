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
        public string Token { get; set; }
       

        public TwitchAuth(string id)
        {
            Token = id;
        }
    }

    
}
