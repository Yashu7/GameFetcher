using GameFetcherUI.DataRecievers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.Factories
{
    public static class GameModelDatabaseRecieverFactory
    {
        public static SingletonFactory<GameModelDataAccess> Factory { get; private set; }
        static GameModelDatabaseRecieverFactory()
        {
            Factory = new SingletonFactory<GameModelDataAccess>();
        }
    }
}
