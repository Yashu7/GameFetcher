using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.ViewModel
{
    public class GameDetailsViewModel : ViewModelBase
    {
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
        public GameDetailsViewModel()
        {
            Game = StaticData.Instance.Model;
            DataContext = this;
           
        }
    }
}
