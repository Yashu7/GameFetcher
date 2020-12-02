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
        public static TwitchAuth bearer;
        public static async Task<TwitchAuth> GetAuth(string clientId,string clientSecret)
        {
            //Get bearer by sending Twitch credentials
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("https://id.twitch.tv/oauth2/token?client_id="+clientId+"&client_secret="+clientSecret+"&grant_type=client_credentials", null).ConfigureAwait(false);
            bearer = await response.Content.ReadAsAsync<TwitchAuth>().ConfigureAwait(false);
            return bearer;
        }
        public static string GetBearer()
        {
            return bearer.Token;
        }
    }
}
