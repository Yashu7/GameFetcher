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
        private static TwitchAuth bearer;

        /// <summary>
        /// Create access token from Twitch API providing correct ClientId and ClientSecret which can be generated at Twitch website
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns>Model of Twitch Authorization Bearer with token</returns>
        public static async Task<TwitchAuth> GetAuth(string clientId,string clientSecret)
        {
            //Get bearer by sending Twitch credentials
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                
                    var response = await client.PostAsync(new Uri("https://id.twitch.tv/oauth2/token?client_id=") + clientId + "&client_secret=" + clientSecret + "&grant_type=client_credentials", null).ConfigureAwait(false);
                
                bearer = await response.Content.ReadAsAsync<TwitchAuth>().ConfigureAwait(true);
            }
            return bearer;
        }
       
        
    }
}
