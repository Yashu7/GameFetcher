using GameFetcherLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.ViewModel
{
    public class GameDetailsViewModel : ViewModelBase, IView
    {
        #region  Fields, properites
        private IGameDetailsModel _game;
        public IGameDetailsModel Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public GameDetailsViewModel()
        {
            Game = PickedGameSingleton.Instance.Model;
            DataContext = this;
        }
        #endregion
    }
}
