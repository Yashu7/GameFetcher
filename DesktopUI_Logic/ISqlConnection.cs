﻿using DesktopUI_Logic.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DesktopUI_Logic
{
    public interface ISqlConnection
    {
        List<IGameDetailsModel> AddPlatformsToGames(List<IGameDetailsModel> games);
        ObservableCollection<IPlatformModel> GetPlatformModels();
        void PostCommand(IGameDetailsModel game);
        void PostPlatforms(ObservableCollection<IPlatformModel> platforms);
        List<IGameDetailsModel> ReadCommand();
        void RemoveCommand(IGameDetailsModel game);
        void UpdateCommand(IGameDetailsModel game);
    }
}