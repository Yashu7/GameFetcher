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
        public GameDetailsModel _game;
        public GameStatus(GameDetailsModel game)
        {
            _game = game;
            this.DataContext = game;
            InitializeComponent();
        }

        private void ChangeStatus(object sender, RoutedEventArgs e)
        {
            RadioButton ck = sender as RadioButton;
            _game.playingStatus = ((GameDetailsModel.Status)ck.Name.Length - 1);
            MessageBox.Show(_game.playingStatus.ToString());
                
        }

        private void ApplyChanges(object sender, RoutedEventArgs e)
        {
            ToSqlConnection sqlConn = new ToSqlConnection();
            sqlConn.UpdateCommand(_game);
        }
    }
}
