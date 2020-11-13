using DesktopUI_Logic.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopUI_Logic
{
    public interface ISqlConnection
    {
        List<GameDetailsModel> AddPlatformsToGames(List<GameDetailsModel> games);
        ObservableCollection<PlatformModel> GetPlatformModels();
        void PostCommand(GameDetailsModel game);
        void PostPlatforms(ObservableCollection<PlatformModel> platforms);
        List<GameDetailsModel> ReadCommand();
        void RemoveCommand(GameDetailsModel game);
        void UpdateCommand(GameDetailsModel game);
    }
}