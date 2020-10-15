using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
     public static class TwitchApiCalls
    {
        public static async Task<TwitchAuth> GetAuth()
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("https://id.twitch.tv/oauth2/token?client_id=3yo2gt2qjjburcphl30wfyt0e64vxx&client_secret=hushpsrjlwb37log7vpjcux79mje3x&grant_type=client_credentials", null);
            TwitchAuth result = await response.Content.ReadAsAsync<TwitchAuth>();
            return result;
            


        }
    }
}
