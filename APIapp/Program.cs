using Newtonsoft.Json;
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
    class Program
    {
        static async Task Main(string[] args)
        {
            GamesApiCalls apiCalls = new GamesApiCalls();
            await apiCalls.ConnectToApi();
            //TwitchAuth loggedToken = await TwitchApiCalls.GetAuth();
            //Console.WriteLine(loggedToken.token);



        }

       
        


    }


}
