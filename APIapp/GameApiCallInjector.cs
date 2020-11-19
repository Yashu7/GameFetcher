using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class GameApiCallInjector
    {
        private readonly IGamesApiCalls GamesApiCalls;
        public GameApiCallInjector(IGamesApiCalls gamesApiCalls) => GamesApiCalls = gamesApiCalls;
        public GameApiCallInjector() => GamesApiCalls = new GamesApiCalls();
        public async Task<string> GetGamesByTitle(string title) => await GamesApiCalls.GetGameByTitle(title);
        public async Task<string> GetAllPlatforms() => await GamesApiCalls.GetAllPlatforms();
        

    }
}
