using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherLogic
{
    public sealed class HttpStaticClient
    {
        private static volatile HttpClient Instance;
        private static readonly object SyncRoot = new object();

        private HttpStaticClient() { }

        public static HttpClient GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (Instance == null)
                            Instance = new HttpClient();
                    }
                }

                return Instance;
            }
        }
    }
}
