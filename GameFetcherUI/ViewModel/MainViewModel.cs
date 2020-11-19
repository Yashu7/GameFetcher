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
using System.Security.Cryptography.X509Certificates;
using SwitchEshopCrawler;
using APIapp;
using GameFetcherUI.View;

namespace GameFetcherUI.ViewModel 
{
    public class MainViewModel : ViewModelBase
    {
        
        #region fields and properties
        private ObservableCollection<IGameDetailsModel> _games = new ObservableCollection<IGameDetailsModel>();
        public ObservableCollection<IGameDetailsModel> Games {
            get { return _games; }
            set { _games = value; OnPropertyChanged(); } }
        private string _choice = "";
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
        private readonly SqlConnectionInjector GamesSource = new SqlConnectionInjector();
        #endregion

        #region Constructor
        public MainViewModel()
        {


            SalesChecker s = new SalesChecker();

         

            Games = new ObservableCollection<IGameDetailsModel>(GamesSource.GetAllGames());
            SalesCommand = new RelayCommand(new Action<object>(ShowSales));
            SearchCommand = new RelayCommand(new Action<object>(SearchGame));
            QuitAppCommand = new RelayCommand(new Action<object>(QuitApp));
            GameDetailsCommand = new RelayCommand(new Action<object>(ShowGameDetails));
            DeleteGameCommand = new RelayCommand(new Action<object>(DeleteGame));
            MoveItemRightCommand = new RelayCommand(new Action<object>(ShowGameDetails));
            EnterCommand = new RelayCommand(new Action<object>(ShowGameDetails));
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
        #endregion
       
        #region Methods
        private void SearchGame(object sender)
        {
            
            AddGamePage addGamePage = new AddGamePage();
            addGamePage.Show();
        }
        private void ShowSales(object sender)
        {
            if (sender == null) return;
            StaticData.Instance.Model = sender as IGameDetailsModel;
            CheckDiscounts checkDiscounts = new CheckDiscounts();
            checkDiscounts.Show();
        
        }
        private void QuitApp(object sender)
        {
            (sender as Window).Close();
        }
        private void ShowGameDetails(object sender)
        {
            if (sender == null) return;
            
            StaticData.Instance.Model = sender as IGameDetailsModel;
            GameStatus gameStatus = new GameStatus();
            gameStatus.Show();
        }
        private void DeleteGame(object sender)
        {
            
            if (sender == null) return;
            GamesSource.RemoveGame(sender as IGameDetailsModel);
           
          
        }
        private void ChooseList(object sender)
        {

            switch (sender)
            {
                case "0":
                    Label = "All Games";
                    var a = GamesSource.GetAllGames();
                    Games = new ObservableCollection<IGameDetailsModel>(a);
                    break;
                case "1":
                    Label = "Played Games";
                    var b = GamesSource.GetPlayedGames();
                    Games = new ObservableCollection<IGameDetailsModel>(b);
                    
                    break;
                case "2":
                    Label = "Playing Games";
                    var c = GamesSource.GetPlayingNowGames();
                    Games = new ObservableCollection<IGameDetailsModel>(c);
                    break;
                case "3":
                    Label = "Not Played Games";
                    var d = GamesSource.GetNotPlayedGames();
                    Games = new ObservableCollection<IGameDetailsModel>(d);
                    break;
                case "4":
                    Label = "Upcoming Games";
                    var e = GamesSource.GetUpcomingGames();
                    Games = new ObservableCollection<IGameDetailsModel>(e);
                    break;
                default:
                    MessageBox.Show("Pick List");
                    break;
            }
        }
        #endregion
    }
}
