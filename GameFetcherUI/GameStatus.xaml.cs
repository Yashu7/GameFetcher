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
    /// Interaction logic for GameStatus.xaml
    /// </summary>
    public partial class GameStatus : Window
    {
        public List<int> ratingList = new List<int>() {1,2,3,4,5,6,7,8,9,10};
        public GameDetailsModel _game;
        public GameStatus(GameDetailsModel game)
        {
            _game = game;
            this.DataContext = game;

            
            InitializeComponent();
            PlatList.ItemsSource = game.AllPlatforms;
            try
            {
                foreach (var i in ratingList)
                {
                    Rating.Items.Add(i);
                }
                Rating.Items.Add("None");
                int s = Convert.ToInt32(_game.MyScore);
                Rating.SelectedItem = s;
                
            }
            catch(Exception ex)
            {
                Main main = new Main();
                main.Show();
                this.Close();
            }
            
        }

        private void ChangeStatus(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            _game.playingStatus = ((GameDetailsModel.Status)ck.Name.Length - 1);
           
                
        }

        private void ApplyChanges(object sender, RoutedEventArgs e)
        {
            _game.MyScore = Convert.ToInt32(Rating.SelectedItem);
            _game.PlatformPlaying = PlatList.SelectedItem.ToString();
            ToSqlConnection sqlConn = new ToSqlConnection();
            sqlConn.UpdateCommand(_game);
            Main main = new Main();
            main.Show();
            this.Close();
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(e.GetPosition(this).ToString());
        }
    }
}
