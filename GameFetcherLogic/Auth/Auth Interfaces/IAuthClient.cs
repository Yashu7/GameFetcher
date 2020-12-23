using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic.Auth
{
    public interface IAuthClient : IObject
    {
        string ReturnToken();
        Task GetAuth();
    }
}
