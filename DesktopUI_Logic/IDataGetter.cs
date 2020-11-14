using DesktopUI_Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopUI_Logic
{
    public interface IDataGetter
    {
        Task<List<IPlatformModel>> GetAllPlatforms();
        Task<List<GameDetailsModel>> GetGameByTitle(string title, int platId);
    }
}