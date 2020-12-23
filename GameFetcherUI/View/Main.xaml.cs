using GameFetcherLogic;
using GameFetcherLogic.Models;
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
    public partial class Main : Window, IView
    {
        public Main(IView view)
        {
             
            InitializeComponent();
            DataContext = view;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
