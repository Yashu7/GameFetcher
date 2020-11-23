using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.API
{
     public interface IApiClient<T>
    {
        Task<HttpClient> Connect();
        Task<T> GetByValue(T value);
        Task<T> GetAll();

    }
}
