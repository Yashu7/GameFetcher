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
    public class MainViewModel : UserControl, INotifyPropertyChanged
    {

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private ObservableCollection<GameDetailsModel> _games = new ObservableCollection<GameDetailsModel>();
        public ObservableCollection<GameDetailsModel> Games {
            get { return _games; }
            set { _games = value; NotifyPropertyChanged("Games"); } }
        private string _choice = "";
        private string _label = "All Games";
        public string Label { get { return _label; } set { _label = value; NotifyPropertyChanged("Label"); } }
        public string Choice
        {
            get { return _choice; }
            set
            {
                ChooseList(value);
                if (value != _choice)
                {

                    _choice = value;
                    PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs("Choice"));

                }
            }
        }
        public ToSqlConnection sqlConn;
        public MainViewModel()
        {
            
            sqlConn = new ToSqlConnection();
            Games = new ObservableCollection<GameDetailsModel>(sqlConn.ReadCommand());
            
            
            SalesCommand = new RelayCommand(new Action<object>(ShowSales));
            SearchCommand = new RelayCommand(new Action<object>(SearchGame));
            QuitAppCommand = new RelayCommand(new Action<object>(QuitApp));
            GameDetailsCommand = new RelayCommand(new Action<object>(ShowGameDetails));
            DeleteGameCommand = new RelayCommand(new Action<object>(DeleteGame));
            DataContext = this;
            
        }


       

        public event PropertyChangedEventHandler PropertyChanged;
       

        #region ICommandDefinitions
        public ICommand SalesCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand GameDetailsCommand { get; private set; }
        public ICommand DeleteGameCommand { get; private set; }
        public ICommand QuitAppCommand { get; private set; }
        #endregion

        private void SearchGame(object sender)
        {
            
            AddGamePage addGamePage = new AddGamePage();
            addGamePage.Show();
        }
        private void ShowSales(object sender)
        {
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
            GameStatus gameStatus = new GameStatus(sender as GameDetailsModel);
            gameStatus.Show();
        }
        private void DeleteGame(object sender)
        {
            
            if (sender == null) return;
            ToSqlConnection sqlConn = new ToSqlConnection();
            sqlConn.RemoveCommand(sender as GameDetailsModel);
          
        }
        private void ChooseList(object sender)
        {

            switch (sender)
            {
                case "0":
                    Label = "All Games";
                    var a = sqlConn.ReadCommand();
                    Games = new ObservableCollection<GameDetailsModel>(a);
                    break;
                case "1":
                    Label = "Played Games";
                    var b = sqlConn.ReadCommand().Where(x => x.playingStatus == GameDetailsModel.Status.Played);
                    Games = new ObservableCollection<GameDetailsModel>(b);
                    
                    break;
                case "2":
                    Label = "Playing Games";
                    var c = sqlConn.ReadCommand().Where(x => x.playingStatus == GameDetailsModel.Status.Playing);
                    Games = new ObservableCollection<GameDetailsModel>(c);
                    break;
                case "3":
                    Label = "Not Played Games";
                    var d = sqlConn.ReadCommand().Where(x => x.playingStatus == GameDetailsModel.Status.Not_Played);
                    Games = new ObservableCollection<GameDetailsModel>(d);
                    break;
                case "4":
                    Label = "Upcoming Games";
                    var e = sqlConn.ReadCommand().Where(x => x.FirstReleaseDate >= Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds));
                    Games = new ObservableCollection<GameDetailsModel>(e);
                    break;
                default:
                    MessageBox.Show("Pick List");
                    break;
            }
        }
    }
}
