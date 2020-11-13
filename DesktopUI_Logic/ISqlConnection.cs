using DesktopUI_Logic.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopUI_Logic
{
    public interface ISqlConnection
    {
        List<IGameDetailsModel> AddPlatformsToGames(List<IGameDetailsModel> games);
        ObservableCollection<PlatformModel> GetPlatformModels();
        void PostCommand(IGameDetailsModel game);
        void PostPlatforms(ObservableCollection<PlatformModel> platforms);
        List<IGameDetailsModel> ReadCommand();
        void RemoveCommand(IGameDetailsModel game);
        void UpdateCommand(IGameDetailsModel game);
    }
}