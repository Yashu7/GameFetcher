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
        public static BaseFactory<GameModelDatabaseReciever> Factory { get; private set; }
        static GameModelDatabaseRecieverFactory()
        {
            Factory = new BaseFactory<GameModelDatabaseReciever>();
        }
    }
}
