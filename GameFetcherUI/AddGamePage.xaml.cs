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
    /// Interaction logic for AddGamePage.xaml
    /// </summary>
    public partial class AddGamePage : Window
    {
        private DataGetter dataGetter = new DataGetter();
        public AddGamePage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            List<GameDetailsModel> gameList = await dataGetter.GetGameByTitle(GameTitleString.Text);
            GameList.ItemsSource = gameList;
            


        }
        
      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GameList.SelectedItem == null) return;
            GameDetails details = new GameDetails(GameList.SelectedItem as GameDetailsModel);
            details.Show();
            //this.Close();
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (GameList.SelectedItem == null) return;
            ToSqlConnection sqlConn = new ToSqlConnection();
            sqlConn.PostCommand(GameList.SelectedItem as GameDetailsModel);
            Main main = new Main();
            main.Show();
            this.Close();
            
        }
    }
}
