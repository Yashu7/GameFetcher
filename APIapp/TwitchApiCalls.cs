using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
     public class TwitchApiCalls
    {
        public TwitchAuth bearer;
        public async Task<TwitchAuth> GetAuth()
        {
            //Get bearer by sending Twitch credentials
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            /** nie commituj nigdy secreta :) to jest tyko do developmentu - docelowo aplikacja powinna użyać np. user flow https://auth0.com/docs/authorization/which-oauth-2-0-flow-should-i-use **/
            var response = await client.PostAsync("https://id.twitch.tv/oauth2/token?client_id=3yo2gt2qjjburcphl30wfyt0e64vxx&client_secret=hushpsrjlwb37log7vpjcux79mje3x&grant_type=client_credentials", null).ConfigureAwait(false);
            bearer = await response.Content.ReadAsAsync<TwitchAuth>().ConfigureAwait(false);
            return bearer;
        }
        public string GetBearer()
        {
            return bearer.Token;
        }
    }
}
