using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.ViewModel
{
    public class CheckDiscountsViewModel : ViewModelBase
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
        public CheckDiscountsViewModel()
        {
            Game = StaticData.Instance.Model;
            DataContext = this;
        }
    }
}
