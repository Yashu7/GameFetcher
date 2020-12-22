using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp.Auth
{
    public interface IAuthClient : IObject
    {
        string ReturnToken();
        Task GetAuth();
    }
}
