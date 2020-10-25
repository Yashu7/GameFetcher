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
        
        public Main(GameDetailsModel gm)
        {
            InitializeComponent();
            Games.gameModels.Add(gm);
            MyGamesList.ItemsSource = Games.gameModels;
            
        }
        public Main()
        {
            InitializeComponent();
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
            if (MyGamesList.SelectedItem == null) return;
            Games.gameModels.Remove(MyGamesList.SelectedItem as GameDetailsModel);
            MyGamesList.ItemsSource = null;
            MyGamesList.ItemsSource = Games.gameModels;
            
            

        }
        // Details window button
        private void GameDetails(object sender, RoutedEventArgs e)
        {
            if (MyGamesList.SelectedItem == null) return;
            GameDetails gameDetails = new GameDetails(MyGamesList.SelectedItem as GameDetailsModel);
            gameDetails.Show();

        }
        //Close App
        private void QuitApp (object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
