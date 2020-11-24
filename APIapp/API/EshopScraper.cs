using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.API
{
    public class EshopScraper : IApiClient<string>
    {
        public Task<HttpClient> Connect()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetByValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
