using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ApiConsumer
{
    
    public class ApiHelper
    {
        //public ApiHelper(string _url, string _context )
        //{
        //    url = _url;
        //    context = _context;
        //}
        //private string url;
        //private string context;

        //public void SetUpConnection()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri(url);
        //        httpClient.DefaultRequestHeaders.Accept.Clear();
        //        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
        //        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        //        ServicePointManager.ServerCertificateValidationCallback = (snder, cert, chain, error) => true;
        //        var result = httpClient.GetAsync(context);
        //        result.Wait();
        //        var response = result.Result;
                
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var n = response.Content.ReadAsStringAsync();
        //            n.Wait();
        //            Console.Write(n.Result);
        //        }
        //        else
        //        {
        //          Console.Write(response.ReasonPhrase);
        //        }

        //    }

        //}




    }
}
