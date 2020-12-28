using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.Factories
{
    public class BaseFactory<T> where T : new()
    {
        private T Instance;
        public T GetInstance()
        {
            if (Instance == null)
            {
                Instance = new T();
            }
            return Instance;
        }

    }
}
