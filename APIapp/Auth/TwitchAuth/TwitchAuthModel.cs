using APIapp.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public sealed class TwitchAuth : IAuthModel
    
    {
        [JsonProperty("access_token")]
        public string Token { get; private set; }

        public TwitchAuth(string id)
        {
            Token = id;
        }
    }

    
}
