using System;
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
using GameFetcherUI.Models;
using GameFetcherUI.DataRecievers;
using GameFetcherUI.Factories;
using AutoMapper;
using System.Collections.Generic;

namespace GameFetcherUI.ViewModel
{
    public class AddGamePageViewModel : UserControl, INotifyPropertyChanged, IView
    {
        #region Fields,properties, lists
        private IDatabaseReciever<GameModel> GameModelDataReciever { get; set; }
        private IDatabaseReciever<Models.PlatformModel> PlatformModelDataReciever { get; set; }

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
        private ObservableCollection<GameModel> _Games = new ObservableCollection<GameModel>();
        public ObservableCollection<GameModel> Games
        {
            get { return _Games; }
            set { _Games = value; NotifyPropertyChanged("Games"); }
        }
        // List of platforms taken from database
        private ObservableCollection<Models.PlatformModel> _Platforms = new ObservableCollection<Models.PlatformModel>();
        public ObservableCollection<Models.PlatformModel> Platforms
        {
            get { return _Platforms; }
            set { _Platforms = value; NotifyPropertyChanged("Platforms"); }
        }
        #endregion

        #region Constructor
        public AddGamePageViewModel()
        {
            
            GameModelDataReciever = GameModelDatabaseRecieverFactory.Factory.GetInstance();
            PlatformModelDataReciever = PlatformModelDatabaseRecieverFactory.Factory.GetInstance();
            //Command Initialization
            DetailsCommand = new RelayCommand(new Action<object>(ShowDetails));
            AddCommand = new RelayCommand(new Action<object>(AddGame));
            SearchCommand = new RelayCommand(new Action<object>(SearchGames));

            //Assign Platforms
            Platforms = new ObservableCollection<Models.PlatformModel>(PlatformModelDataReciever.GetAll());

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
            if ((GameModel)sender == null) return;
            PickedGameSingleton.Instance.Model = (GameModel)sender;
            UnityResolver.Container.Resolve<GameDetails>().Show();
           
        }
        /// <summary>
        /// Add picked game to the database source.
        /// </summary>
        /// <param name="sender"></param>
        private void AddGame(object sender)
        {
            if (!(sender is GameModel game)) return;
            GameModelDataReciever.Insert(game);
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
            Models.PlatformModel selectedPlatform = sender as Models.PlatformModel;
            Models.PlatformModel platform = selectedPlatform;
            
            ObservableCollection<GameModel> gameList = new ObservableCollection<GameModel>(new Mapper(App.Config).Map<List<GameModel>>(await dataReciever.GetByValue(SearchString, platform.PlatformId).ConfigureAwait(false)));

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
