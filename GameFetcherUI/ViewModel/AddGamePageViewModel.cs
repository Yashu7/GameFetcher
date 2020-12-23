using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GameFetcherLogic.Models;
using GameFetcherLogic;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using GameFetcherLogic.Unity;
using Unity;
using GameFetcherLogic.ApiServices;
using GameFetcherUI.Unity;

namespace GameFetcherUI.ViewModel
{
    public class AddGamePageViewModel : UserControl, INotifyPropertyChanged, IView
    {
        #region Fields,properties, lists
        // SQL Interface for Unity Container
        readonly ISqlConnectionInjector<IGameDetailsModel> GameSource;
        // SQL Interface for Unity Container
        readonly ISqlConnectionInjector<IPlatformModel> PlatformSource;
        
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
        // List of games taken from API
        private ObservableCollection<IGameDetailsModel> _Games = new ObservableCollection<IGameDetailsModel>();
        public ObservableCollection<IGameDetailsModel> Games
        {
            get { return _Games; }
            set { _Games = value; NotifyPropertyChanged("Games"); }
        }
        // List of platforms taken from database
        private ObservableCollection<IPlatformModel> _Platforms = new ObservableCollection<IPlatformModel>();
        public ObservableCollection<IPlatformModel> Platforms
        {
            get { return _Platforms; }
            set { _Platforms = value; NotifyPropertyChanged("Platforms"); }
        }
        #endregion

        #region Constructor
        public AddGamePageViewModel()
        {
            //Unity Initialization
            
            GameSource = UnityRegister.Container.Resolve<ISqlConnectionInjector<IGameDetailsModel>>();
            PlatformSource = UnityRegister.Container.Resolve<ISqlConnectionInjector<IPlatformModel>>();

            //Command Initialization
            DetailsCommand = new RelayCommand(new Action<object>(ShowDetails));
            AddCommand = new RelayCommand(new Action<object>(AddGame));
            SearchCommand = new RelayCommand(new Action<object>(SearchGames));

            //Assign Platforms
            Platforms = new ObservableCollection<IPlatformModel>(PlatformSource.SelectAll());

            DataContext = this;
        }
        #endregion

        #region INotifyProperty
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        #region ICommands declaration
        public ICommand DetailsCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        #endregion
     
        #region Methods
        /// <summary>
        /// Opens window with details about picked game.
        /// </summary>
        /// <param name="sender"></param>
        private void ShowDetails(object sender)
        {
            IGameDetailsModel game = sender as IGameDetailsModel;
            if (game == null) return;
            StaticData.Instance.Model = game;
            UnityResolver.Container.Resolve<GameDetails>().Show();
           
        }
        /// <summary>
        /// Add picked game to the database source.
        /// </summary>
        /// <param name="sender"></param>
        private void AddGame(object sender)
        {
            if (!(sender is IGameDetailsModel game)) return;
            GameSource.InsertGame(game);
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
            var dataReciever = UnityRegister.Container.Resolve<IDataReciever<GameDetailsModel, string, int>>("GameModelsReciever");
            PlatformModel selectedPlatform = sender as PlatformModel;
            PlatformModel platform = selectedPlatform;
            ObservableCollection<IGameDetailsModel> gameList = new ObservableCollection<IGameDetailsModel>(await dataReciever.GetByValue(SearchString, platform.platformId).ConfigureAwait(false));

            Games = gameList;
        }

        //Reset form fields
        public void EmptyOutFields()
        {
            Games = null;
            SearchString = "Insert Game Title";
        }
        #endregion

    }
}
