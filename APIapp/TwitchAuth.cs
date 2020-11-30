using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class TwitchAuth
    /** do czego jest ta struktura danych? **/
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
       

        public TwitchAuth(string id)
        /** metody powinny być czasownikami nie rzeczownikami - metody coś robią **/
        {
            Token = id;
        }
    }

    
}
