using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic.ApiClients.Interfaces
{
    interface IApiClient<T>
    {
        Task<List<T>> GetAll();
        Task<List<T>> Get(string value);
    }
}
