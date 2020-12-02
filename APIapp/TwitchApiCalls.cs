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
            var response = await client.PostAsync("https://id.twitch.tv/oauth2/token?client_id=3yo2gt2qjjburcphl30wfyt0e64vxx&client_secret=hushpsrjlwb37log7vpjcux79mje3x&grant_type=client_credentials", null).ConfigureAwait(false);
            /** metoda nie powinna raczej zwracać czegoś i jednocześnie zmieniać stanu obiektu - po prostu zwróć bearer i nie utrzymój stanu **/
            bearer = await response.Content.ReadAsAsync<TwitchAuth>().ConfigureAwait(false);
            return bearer;
        }
        public static string GetBearer()
        {
            return bearer.Token;
        }
    }
}
