using GameFetcherLogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI
{
    public sealed class PickedGameSingleton
    {
       
        public IGameDetailsModel Model { get; set; }
        PickedGameSingleton()
        {
            
        }
        private static readonly object padlock = new object();
        private static PickedGameSingleton _instance;
        public static PickedGameSingleton Instance
        {
            get
            {
                lock(padlock)
                {
                    if(_instance == null)
                    {
                        _instance = new PickedGameSingleton();
                    }
                    return _instance;
                }
            }
        }
    }
}
