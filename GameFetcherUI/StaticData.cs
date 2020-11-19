using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI
{
    public sealed class StaticData
    {
       
        public IGameDetailsModel Model { get; set; }
        StaticData()
        {
            
        }
        private static readonly object padlock = new object();
        private static StaticData _instance;
        public static StaticData Instance
        {
            get
            {
                lock(padlock)
                {
                    if(_instance == null)
                    {
                        _instance = new StaticData();
                    }
                    return _instance;
                }
            }
        }
    }
}
