using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.DataRecievers
{
    interface IDatabaseReciever<T>
    {
        List<T> GetAll();
        List<T> GetBy(T name);
        void Delete(T name);
        void Update(T name);
        void Insert(T name);

    }
}
