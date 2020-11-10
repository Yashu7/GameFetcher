using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DesktopUI_Logic.Models;
using DesktopUI_Logic;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GameFetcherUI.ViewModel
{
    public class AddGamePageViewModel : UserControl, INotifyPropertyChanged
    {


        private ObservableCollection<GameDetailsModel> _Games = new ObservableCollection<GameDetailsModel>();
        public ObservableCollection<GameDetailsModel> Games
        {
            get { return _Games; }
            set { _Games = value; NotifyPropertyChanged("Games"); }
        }

        private ObservableCollection<PlatformModel> _Platforms = new ObservableCollection<PlatformModel>();
        public ObservableCollection<PlatformModel> Platforms
        {
            get { return _Platforms; }
            set { _Platforms = value; NotifyPropertyChanged("Platforms"); }
        }
        public AddGamePageViewModel()
        {
            DetailsCommand = new RelayCommand(new Action<object>(ShowDetails));
            AddCommand = new RelayCommand(new Action<object>(AddGame));
            SearchCommand = new RelayCommand(new Action<object>(SearchGames));
            ToSqlConnection sqlConn = new ToSqlConnection();
            Platforms = sqlConn.GetPlatformModels();
            DataContext = this;
            
        }

      

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public ICommand DetailsCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
      
        private void ShowDetails(object sender)
        {
            GameDetailsModel game = sender as GameDetailsModel;
            if (game == null) return;
            GameDetails details = new GameDetails(game);
            details.Show();
        }
        private void AddGame(object sender)
        {
            if (!(sender is GameDetailsModel game)) return;
            ToSqlConnection sqlConn = new ToSqlConnection();
            sqlConn.PostCommand(game);
            MessageBox.Show("Game Added");
            DataContext = null;
            DataContext = this;
            //Close this window?
        }
        private async void SearchGames(object sender)
        {
            PlatformModel selectedPlatform = sender as PlatformModel;
            PlatformModel platform = selectedPlatform;
            ObservableCollection<GameDetailsModel> gameList = await dataGetter.GetGameByTitle(GameTitleString.Text, platform.platformId);

            Games = gameList;
        }

    }
}
