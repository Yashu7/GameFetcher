using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class GamesApiCalls
    {
        public void ConnectToApi(string id, string token)
        {
            var apiCall = new HttpClient();
            apiCall.DefaultRequestHeaders.Accept.Clear();
            apiCall.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var result = apiCall.PostAsync("https://api.igdb.com/v4/games?Client-ID="+id+"&")
        }
    }
}
