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
    /// Interaction logic for GameDetails.xaml
    /// </summary>
    public partial class GameDetails : Window, IView
    {
        public GameDetails(IView view)
        {
            InitializeComponent();
            DataContext = view;
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
   
}
