using GameFetcherUI.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopUI_Logic;

namespace GameFetcherUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string GameTitle;
        private DataGetter dataGetter = new DataGetter();
        public MainWindow()
        {
            
           
            InitializeComponent();
            
        }

        public async Task GetData()
        {
            GameDetailsModel gameModel = new GameDetailsModel { GameTitle = GameTitle };
            GameTitle = await dataGetter.GetData();
            this.DataContext = gameModel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           await GetData();
        }
    }   
}
