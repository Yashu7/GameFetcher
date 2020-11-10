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
       
        public AddGamePage()
        {
            
            InitializeComponent();
            GetPlatforms();


        }

        public void GetPlatforms()
        {
           
           
            
           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //PlatformModel platform = PlatformsDropDown.SelectedItem as PlatformModel;
            //ObservableCollection<GameDetailsModel> gameList = await dataGetter.GetGameByTitle(GameTitleString.Text, platform.platformId);
            
           // GameList.ItemsSource = gameList;
            



        }
        
      

       

        
    }
}
