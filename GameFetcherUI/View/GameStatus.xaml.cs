using DesktopUI_Logic;
using DesktopUI_Logic.Models;
using GameFetcherUI.ViewModel;
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
    /// Interaction logic for GameStatus.xaml
    /// </summary>
    public partial class GameStatus : Window
    {
        public List<int> ratingList = new List<int>() {1,2,3,4,5,6,7,8,9,10};
        public GameDetailsModel _game;
        public GameStatus(GameDetailsModel game)
        {

            //this.DataContext = game;

            _game = game;
            InitializeComponent();
            
            //((GameStatusViewModel)DataContext).Game = _game;
           // MessageBox.Show(((GameStatusViewModel)this.DataContext).Game.Summary);
            //PlatList.ItemsSource = game.AllPlatforms;
            //PlatList.SelectedItem = _game.PlatformPlaying;
            //PlayingStatus.ItemsSource = game.Enums;
            //PlayingStatus.SelectedItem = game.GetStatus;
            
               foreach (var i in ratingList)
               {
                    Rating.Items.Add(i);
                }
                Rating.Items.Add("None");
           
            
        }

       

        private void ApplyChanges(object sender, RoutedEventArgs e)
        {
            //_game.MyScore = Convert.ToInt32(Rating.SelectedItem);
            //_game.PlatformPlaying = PlatList.SelectedItem.ToString();
            //_game.playingStatus = (GameDetailsModel.Status)PlayingStatus.SelectedItem;
            //ToSqlConnection sqlConn = new ToSqlConnection();
            //sqlConn.UpdateCommand(_game);
           
            //this.Close();
            
        }

        
    }
}
