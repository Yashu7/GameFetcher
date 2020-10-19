using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class GamesApiCalls
    {
        public async Task ConnectToApi()
        {
            var apiCall = new HttpClient();
            apiCall.BaseAddress = new Uri("https://api.igdb.com/v4/games");
            apiCall.DefaultRequestHeaders.Accept.Clear();
            apiCall.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            apiCall.DefaultRequestHeaders.Add("Client-ID", "3yo2gt2qjjburcphl30wfyt0e64vxx");
            apiCall.DefaultRequestHeaders.Add("Authorization", "Bearer rghpew8l8lkpd122qar5i3x5fz32nc");
            HttpContent requestMessage;
            requestMessage = new StringContent("fields name;  where id = 1942;", Encoding.UTF8, "application/json");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
            HttpResponseMessage response = await apiCall.PostAsync("https://api.igdb.com/v4/games",requestMessage);
            var result = await apiCall.PostAsync("https://api.igdb.com/v4/games", null);

            var a = response.Content.ReadAsStringAsync();
            Console.WriteLine(a.Result);

            }
    }
}
