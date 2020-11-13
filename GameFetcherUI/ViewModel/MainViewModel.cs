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

namespace GameFetcherUI.ViewModel 
{
    public class MainViewModel : ViewModelBase
    {
        
        #region fields and properties
        public StaticData dataSource;
        private ObservableCollection<GameDetailsModel> _games = new ObservableCollection<GameDetailsModel>();
        public ObservableCollection<GameDetailsModel> Games {
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
        public SqlConnectionInjector GamesSource = new SqlConnectionInjector();
        #endregion

        #region Constructor
        public MainViewModel()
        {
            
            
            Games = new ObservableCollection<GameDetailsModel>(GamesSource.GetAllGames());
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
            GameDetailsModel game = sender as GameDetailsModel;
            SalesChecker sales = new SalesChecker();
            try
            {
                MessageBox.Show("Discount price on steam is : " + sales.CheckSteamSale(game));
            }
            catch (Exception)
            {
                MessageBox.Show("Game is not on sale");
            }
        }
        private void QuitApp(object sender)
        {
            (sender as Window).Close();
        }
        private void ShowGameDetails(object sender)
        {

            if (sender == null) return;
                     dataSource = StaticData.Instance;
            dataSource.Model = sender as GameDetailsModel;
            GameStatus gameStatus = new GameStatus();
            gameStatus.Show();
        }
        private void DeleteGame(object sender)
        {
            
            if (sender == null) return;
            GamesSource.RemoveGame(sender as GameDetailsModel);
           
          
        }
        private void ChooseList(object sender)
        {

            switch (sender)
            {
                case "0":
                    Label = "All Games";
                    var a = GamesSource.GetAllGames();
                    Games = new ObservableCollection<GameDetailsModel>(a);
                    break;
                case "1":
                    Label = "Played Games";
                    var b = GamesSource.GetPlayedGames();
                    Games = new ObservableCollection<GameDetailsModel>(b);
                    
                    break;
                case "2":
                    Label = "Playing Games";
                    var c = GamesSource.GetPlayingNowGames();
                    Games = new ObservableCollection<GameDetailsModel>(c);
                    break;
                case "3":
                    Label = "Not Played Games";
                    var d = GamesSource.GetNotPlayedGames();
                    Games = new ObservableCollection<GameDetailsModel>(d);
                    break;
                case "4":
                    Label = "Upcoming Games";
                    var e = GamesSource.GetUpcomingGames();
                    Games = new ObservableCollection<GameDetailsModel>(e);
                    break;
                default:
                    MessageBox.Show("Pick List");
                    break;
            }
        }
        #endregion
    }
}
