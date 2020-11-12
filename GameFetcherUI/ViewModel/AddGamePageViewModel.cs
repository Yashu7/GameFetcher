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
        #region fields,properties, lists
        private string _searchString = "Insert Game Title";
        public string SearchString 
        {
            get
            {
                return _searchString;
            }
            set
            {
                _searchString = value;
                NotifyPropertyChanged("SearchString");
            }
            
        }
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
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public AddGamePageViewModel()
        {
            DetailsCommand = new RelayCommand(new Action<object>(ShowDetails));
            AddCommand = new RelayCommand(new Action<object>(AddGame));
            SearchCommand = new RelayCommand(new Action<object>(SearchGames));
            ToSqlConnection sqlConn = new ToSqlConnection();
            Platforms = sqlConn.GetPlatformModels();
            DataContext = this;
            
        }

      
        /// <summary>
        /// INotifyPropertyChanged Methods
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// ICommands
        /// </summary>
        public ICommand DetailsCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }

        #region methods
        /// <summary>
        /// Opens window with details about picked game.
        /// </summary>
        /// <param name="sender"></param>
        private void ShowDetails(object sender)
        {
            GameDetailsModel game = sender as GameDetailsModel;
            if (game == null) return;
            StaticData.Instance.Model = game;
            GameDetails details = new GameDetails();
            details.Show();
        }
        /// <summary>
        /// Add picked game to the database source.
        /// </summary>
        /// <param name="sender"></param>
        private void AddGame(object sender)
        {
            if (!(sender is GameDetailsModel game)) return;
            ToSqlConnection sqlConn = new ToSqlConnection();
            sqlConn.PostCommand(game);
            MessageBox.Show("Game Added");
            EmptyOutFields();
            //Close this window?
        }
        /// <summary>
        /// Based on chosen title and platform, searches API.
        /// </summary>
        /// <param name="sender"></param>
        private async void SearchGames(object sender)
        {
            DataGetter dataGetter = new DataGetter();
            PlatformModel selectedPlatform = sender as PlatformModel;
            PlatformModel platform = selectedPlatform;
            ObservableCollection<GameDetailsModel> gameList = await dataGetter.GetGameByTitle(SearchString, platform.platformId);

            Games = gameList;
        }

        public void EmptyOutFields()
        {
            Games = null;
            SearchString = "Insert Game Title";
        }
        #endregion

    }
}
