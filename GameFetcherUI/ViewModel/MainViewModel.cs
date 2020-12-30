using System;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using GameFetcherUI.View;
using Unity;
using GameFetcherLogic.Unity;
using GameFetcherUI.Unity;
using GameFetcherLogic.SerializationServices;
using Microsoft.Win32;
using GameFetcherUI.Interfaces;
using GameFetcherUI.Models;
using GameFetcherUI.DataRecievers;
using GameFetcherUI.Factories;
using AutoMapper;
using GameFetcherLogic.Models;
using System.Collections.Generic;

namespace GameFetcherUI.ViewModel
{
    public class MainViewModel : ViewModelBase, IView, IViewCommandSetter
    {

        #region fields and properties
        private IDataAccess<GameModel> GamesRecievier { get; set; }
        private ObservableCollection<GameModel> _games = new ObservableCollection<GameModel>();
        public ObservableCollection<GameModel> Games 
        {
            get { return _games; }
            set { _games = value; OnPropertyChanged(); } 
        }
        //Game List Inumerator
        private string _choice = "0";
        private GameModel _selectedGame;
        public GameModel SelectedGame
        {
            get { return _selectedGame; }
            set { _selectedGame = value;
                OnPropertyChanged();
                if (_selectedGame != null) IsGamePicked = true;
                else
                {
                    IsGamePicked = false;
                }
                }
        }
        private string _label = "All Games";
        public string Label { get { return _label; } set { _label = value; OnPropertyChanged(); } }
        public string Choice
        {
            get { return _choice; }
            set
            {
                ChooseList(value);
                if (value != _choice)
                {
                    _choice = value;
                    OnPropertyChanged();
                }
            }
        }
        // Enable/Disable Buttons
        private bool _isGamePicked = false;
        public bool IsGamePicked
        {
            get { return _isGamePicked; }
            set { _isGamePicked = value;
                OnPropertyChanged();
            }
        }

    
        #endregion

        #region Constructor
        public MainViewModel()
        {

            InstantiateCommands();
            GamesRecievier = GameModelDatabaseRecieverFactory.Factory.GetInstance();
            Games = new ObservableCollection<GameModel>(GamesRecievier.GetAll());
            DataContext = this;
        }
        #endregion

        #region ICommandDefinitions
        public ICommand SalesCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand GameDetailsCommand { get; private set; }
        public ICommand DeleteGameCommand { get; private set; }
        public ICommand QuitAppCommand { get; private set; }
        public ICommand MoveItemRightCommand { get; private set; }
        public ICommand EnterCommand { get; private set; }
        public ICommand ExportList { get; private set; }
        #endregion

        #region Methods
        //Export chosen list to text file
        private void ExportGameList(object obj)
        {
            string path = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                path = saveFileDialog.FileName;
            UnityRegister.Container.Resolve<ISerializer<IGameDetailsModel>>().SerializeList(new Mapper(App.Config).Map<List<IGameDetailsModel>>(Games.ToList()),path);

        }
       
        private void SearchGame(object sender)
        {
            UnityResolver.Container.Resolve<AddGamePage>("AddGame").Show();
        }
        
        private void ShowSales(object sender)
        {
            if (sender == null) return;
            PickedGameSingleton.Instance.Model = sender as GameModel;
            UnityResolver.Container.Resolve<CheckDiscounts>().Show();
        }
        //Close app
        private void QuitApp(object sender)
        {
            
            (sender as Window).Close();
        }
        
        private void ShowGameDetails(object sender)
        {
            if (sender == null) return;
            
            PickedGameSingleton.Instance.Model = sender as GameModel;
            UnityResolver.Container.Resolve<GameStatus>().Show();
           
        }
        
        private void DeleteGame(object sender)
        {
            
            if (sender == null) return;
            var canDelete = MessageBox.Show("Do you want delete this game from your list?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (canDelete == MessageBoxResult.Yes)
            {
                GamesRecievier.Delete(sender as GameModel);
                Games = new ObservableCollection<GameModel>(GamesRecievier.GetAll());
            }


        }
        //Gamelist updated depending on list option change
        public void ChooseList(object sender)
        {

            switch (sender)
            {
                case "0":
                    Label = "All Games";
                    Games = new ObservableCollection<GameModel>(GamesRecievier.GetAll());
                    break;
                case "1":
                    Label = "Played Games";
                    var playedGames = GamesRecievier.GetAll().Where(x => x.GetStatus == GameModel.Status.Played).ToList();
                    Games = new ObservableCollection<GameModel>(playedGames);

                    break;
                case "2":
                    Label = "Playing Games";
                    var playingGames = GamesRecievier.GetAll().Where(x => x.GetStatus == GameModel.Status.Playing).ToList();
                    Games = new ObservableCollection<GameModel>(playingGames);
                    break;
                case "3":
                    Label = "Not Played Games";
                    var notPlayedGames = GamesRecievier.GetAll().Where(x => x.GetStatus == GameModel.Status.Not_Played).ToList();
                    Games = new ObservableCollection<GameModel>(notPlayedGames);
                    break;
                case "4":
                    Label = "Upcoming Games";
                    var upcomingGames = GamesRecievier.GetAll().Where(x => x.FirstReleaseDate >= Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds)).ToList();
                    Games = new ObservableCollection<GameModel>(upcomingGames);
                    break;
                default:
                    MessageBox.Show("Pick List");
                    break;
            }
        }

      

        public void InstantiateCommands()
        {
            SalesCommand = new RelayCommand(new Action<object>(ShowSales));
            SearchCommand = new RelayCommand(new Action<object>(SearchGame));
            QuitAppCommand = new RelayCommand(new Action<object>(QuitApp));
            GameDetailsCommand = new RelayCommand(new Action<object>(ShowGameDetails));
            DeleteGameCommand = new RelayCommand(new Action<object>(DeleteGame));
            MoveItemRightCommand = new RelayCommand(new Action<object>(ShowGameDetails));
            EnterCommand = new RelayCommand(new Action<object>(ShowGameDetails));
            ExportList = new RelayCommand(new Action<object>(ExportGameList));
        }
        #endregion
    }
}
