using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIapp
{
    public class GameApiCallInjector
    {
        private readonly IGamesApiCalls gamesApiCalls;
        public GameApiCallInjector(IGamesApiCalls _gamesApiCalls) => gamesApiCalls = _gamesApiCalls;
        public GameApiCallInjector() => gamesApiCalls = new GamesApiCalls();
        public async Task<string> GetGamesByTitle(string title) => await gamesApiCalls.GetGameByTitle(title);
        public async Task<string> GetAllPlatforms() => await gamesApiCalls.GetAllPlatforms();

    }
}
