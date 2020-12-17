using System;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using DesktopUI_Logic.Models;
using DesktopUI_Logic;
using System.Collections.ObjectModel;
using GameFetcherUI.View;
using Unity;
using DesktopUI_Logic.Unity;
using System.ComponentModel;
using GameFetcherUI.Unity;
using DesktopUI_Logic.SerializationServices;
using System.Collections.Generic;
using Microsoft.Win32;
using System.IO;
using GameFetcherUI.Interfaces;

namespace GameFetcherUI.ViewModel
{
    public class MainViewModel : ViewModelBase, IView, IUnitySetup, IViewCommandSetter
    {

        #region fields and properties
        IUnityContainer viewContainer;
        IUnityContainer container;
        private ObservableCollection<IGameDetailsModel> _games = new ObservableCollection<IGameDetailsModel>();
        public ObservableCollection<IGameDetailsModel> Games 
        {
            get { return _games; }
            set { _games = value; OnPropertyChanged(); } 
        }
        //Game List Inumerator
        private string _choice = "0";
        private IGameDetailsModel _selectedGame;
        public IGameDetailsModel SelectedGame
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

        private readonly ISqlConnectionInjector<IGameDetailsModel> GamesSource;
        #endregion

        #region Constructor
        public MainViewModel()
        {

            //Unity Injection.
            InstantiateUnity();
            InstantiateCommands();
            GamesSource = container.Resolve<ISqlConnectionInjector<IGameDetailsModel>>();
            Games = new ObservableCollection<IGameDetailsModel>(GamesSource.SelectAll());
           
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
            container.Resolve<ISerializer<IGameDetailsModel>>().SerializeList(Games.ToList(),path);

        }
        //Open new window
        private void SearchGame(object sender)
        {
            viewContainer.Resolve<AddGamePage>("AddGame").Show();
        }
        //Open new window
        private void ShowSales(object sender)
        {
            if (sender == null) return;
            StaticData.Instance.Model = sender as IGameDetailsModel;
            viewContainer.Resolve<CheckDiscounts>().Show();
        }
        //Close app
        private void QuitApp(object sender)
        {
            
           
            (sender as Window).Close();
        }
        //Open new window
        private void ShowGameDetails(object sender)
        {
            if (sender == null) return;
            
            StaticData.Instance.Model = sender as IGameDetailsModel;
            viewContainer.Resolve<GameStatus>().Show();
           
        }
        
        private void DeleteGame(object sender)
        {
            
            if (sender == null) return;
            var canDelete = MessageBox.Show("Do you want delete this game from your list?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (canDelete == MessageBoxResult.Yes)
            {
                GamesSource.Delete(sender as IGameDetailsModel);
                Games = new ObservableCollection<IGameDetailsModel>(GamesSource.SelectAll());
            }


        }
        //Gamelist updated depending on list option change
        public void ChooseList(object sender)
        {

            switch (sender)
            {
                case "0":
                    Label = "All Games";
                    var a = GamesSource.SelectAll();
                    Games = new ObservableCollection<IGameDetailsModel>(a);
                    break;
                case "1":
                    Label = "Played Games";
                    var b = GamesSource.SelectAll().Where(x => x.GetStatus == GameDetailsModel.Status.Played).ToList();
                    Games = new ObservableCollection<IGameDetailsModel>(b);
                    
                    break;
                case "2":
                    Label = "Playing Games";
                    var c = GamesSource.SelectAll().Where(x => x.GetStatus == GameDetailsModel.Status.Playing).ToList();
                    Games = new ObservableCollection<IGameDetailsModel>(c);
                    break;
                case "3":
                    Label = "Not Played Games";
                    var d = GamesSource.SelectAll().Where(x => x.GetStatus == GameDetailsModel.Status.Not_Played).ToList();
                    Games = new ObservableCollection<IGameDetailsModel>(d);
                    break;
                case "4":
                    Label = "Upcoming Games";
                    var e = GamesSource.SelectAll().Where(x => x.FirstReleaseDate >= Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds)).ToList();
                    Games = new ObservableCollection<IGameDetailsModel>(e);
                    break;
                default:
                    MessageBox.Show("Pick List");
                    break;
            }
        }

        public void InstantiateUnity()
        {
            container = new UnityContainer();
            UnityRegister.Register(container);
            viewContainer = new UnityContainer();
            UnityResolver.Register(viewContainer);
           
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
