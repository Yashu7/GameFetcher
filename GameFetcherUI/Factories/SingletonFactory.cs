using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.Factories
{
    public class SingletonFactory<T> where T : new()
    {
        private T Instance;
        /// <summary>
        /// Returns instance of T class. New instance, if not already created.
        /// </summary>
        /// <returns></returns>
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
