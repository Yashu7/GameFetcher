using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public sealed class HttpStaticClient
    {

        
        private static volatile HttpClient instance;
        private static object syncRoot = new Object();

        private HttpStaticClient() { }

        public static HttpClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new HttpClient();
                    }
                }

                return instance;
            }
        }
    }
}
