using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DesktopUI_Logic.Models;
using DesktopUI_Logic;

namespace GameFetcherUI.ViewModel
{
    public class MainViewModel
    {
        
        public MainViewModel()
        {
            SalesCommand = new RelayCommand(new Action<object>(Sales));
            SearchCommand = new RelayCommand(new Action<object>(SearchGame));
            QuitAppCommand = new RelayCommand(new Action<object>(QuitApp));
        }


        #region Commands
        private ICommand _SearchCommand;
        private ICommand _SalesCommand;
        private ICommand _GameDetailsCommand;
        private ICommand _DeleteGameCommand;
        private ICommand _QuitAppCommand;
        #endregion

        #region ICommandDefinitions
        public ICommand SalesCommand { get { return _SalesCommand; } set { _SalesCommand = value; } }
        public ICommand SearchCommand { get { return _SearchCommand; } set { _SearchCommand = value; } }
        public ICommand GameDetailsCommand { get { return _GameDetailsCommand; } set { _GameDetailsCommand = value; } }
        public ICommand DeleteGameCommand { get { return _DeleteGameCommand; } set { _DeleteGameCommand = value; } }
        public ICommand QuitAppCommand { get { return _QuitAppCommand; } set { _QuitAppCommand = value; } }
        #endregion

        private void SearchGame(object sender)
        {
            AddGamePage addGamePage = new AddGamePage();
            addGamePage.Show();
        }
        private void Sales(object sender)
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
        
    }
}
