using GameFetcherUI.DataRecievers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.Factories
{
    public static class PlatformModelDatabaseRecieverFactory
    {
        public static SingletonFactory<PlatformModelDataAccess> Factory { get; private set; }
        static PlatformModelDatabaseRecieverFactory()
        {
            Factory = new SingletonFactory<PlatformModelDataAccess>();
        }
    }
}
