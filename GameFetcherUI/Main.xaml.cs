using DesktopUI_Logic;
using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameFetcherUI
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public ToSqlConnection sqlConn;

        public Main()
        {
            sqlConn = new ToSqlConnection();

            InitializeComponent();
            AllGames.ItemsSource = sqlConn.ReadCommand();
            PlayedGames.ItemsSource = sqlConn.ReadCommand().Where(x => x.playingStatus == GameDetailsModel.Status.Played);
            NotPlayedGames.ItemsSource = sqlConn.ReadCommand().Where(x => x.playingStatus == GameDetailsModel.Status.Not_Played);
            PlayingNow.ItemsSource = sqlConn.ReadCommand().Where(x => x.playingStatus == GameDetailsModel.Status.Playing);
            UpcomingGames.ItemsSource = sqlConn.ReadCommand().Where(x => x.FirstReleaseDate >= Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds));
           
        
        }

        // Opens up windows for adding new game.
        private void SearchGame(object sender, RoutedEventArgs e)
        {
            AddGamePage addGamePage = new AddGamePage();
            addGamePage.Show();
            this.Close();
        }

        // Delete button.
        private void DeleteGame(object sender, RoutedEventArgs e)
        {
            if (AllGames.SelectedItem == null) return;
            ToSqlConnection sqlConn = new ToSqlConnection();
            sqlConn.RemoveCommand(AllGames.SelectedItem as GameDetailsModel);
            AllGames.ItemsSource = null;
            AllGames.ItemsSource = sqlConn.ReadCommand();



        }
        // Details window button
        private void GameDetails(object sender, RoutedEventArgs e)
        {

            if (AllGames.SelectedItem == null) return;
            GameDetails gameDetails = new GameDetails(AllGames.SelectedItem as GameDetailsModel);
            gameDetails.Show();

        }
        //Close App
        private void QuitApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
        void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem v = new ListViewItem();
            v = (ListViewItem)sender;
            
            GameDetailsModel model = (GameDetailsModel)v.Content;
            GameStatus gameStatus = new GameStatus(model);
                gameStatus.Show();
            this.Close();


        }

        

        private void Sales(object sender, RoutedEventArgs e)
        {
            GameDetailsModel game = AllGames.SelectedItem as GameDetailsModel;
            SalesChecker sales = new SalesChecker();

            try
            {
                
                MessageBox.Show("Discount price on steam is : " + sales.CheckSteamSale(game));
            }
            catch(Exception)
            {
                MessageBox.Show("Game is not on sale");
            }

        }
    }
}
