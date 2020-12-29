using GameFetcherUI.Interfaces;
using GameFetcherUI.ViewModel;
using System.Collections.Generic;
using System.Windows;


namespace GameFetcherUI
{
    /// <summary>
    /// Interaction logic for GameStatus.xaml
    /// </summary>
    public partial class GameStatus : Window, IView, ICloseable
    {
        private readonly List<int> ratingList = new List<int>() {1,2,3,4,5,6,7,8,9,10};
       
        public GameStatus(IView view)
        {
            InitializeComponent();
            DataContext = view;
            foreach (var i in ratingList)
            {
                 Rating.Items.Add(i);
            }
            Rating.Items.Add("None");
           
        }
       
    }
}
