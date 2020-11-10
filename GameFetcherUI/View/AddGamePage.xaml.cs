using DesktopUI_Logic;
using DesktopUI_Logic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<PlatformModel> platforms;
        public AddGamePage()
        {
            
            InitializeComponent();
            GetPlatforms();


        }

        public void GetPlatforms()
        {
            ToSqlConnection sqlConn = new ToSqlConnection();
            platforms = sqlConn.GetPlatformModels();
           
            PlatformsDropDown.ItemsSource = platforms;
            PlatformsDropDown.DisplayMemberPath = "name";
           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            PlatformModel platform = PlatformsDropDown.SelectedItem as PlatformModel;
            ObservableCollection<GameDetailsModel> gameList = await dataGetter.GetGameByTitle(GameTitleString.Text, platform.platformId);
            
            GameList.ItemsSource = gameList;
            



        }
        
      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (GameList.SelectedItem == null) return;
            GameDetails details = new GameDetails(GameList.SelectedItem as GameDetailsModel);
            details.Show();
            //this.Close();
            
            
        }

        private  void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (GameList.SelectedItem == null) return;
            ToSqlConnection sqlConn = new ToSqlConnection();
           
            sqlConn.PostCommand(GameList.SelectedItem as GameDetailsModel);
            
           
            this.Close();
            
        }
    }
}
