using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using DesktopUI_Logic.Models;
using DesktopUI_Logic;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using DesktopUI_Logic.Unity;
using Unity;
using DesktopUI_Logic.ApiServices;

namespace GameFetcherUI.ViewModel
{
    public class AddGamePageViewModel : UserControl, INotifyPropertyChanged
    {
        #region fields,properties, lists
        readonly ISqlConnectionInjector<IGameDetailsModel> GameSource;
        readonly ISqlConnectionInjector<IPlatformModel> PlatformSource;
        private IUnityContainer container;
        private string _searchString = "Insert Game Title";
        public string SearchString 
        {
            get
            {
                return _searchString;
            }
            set
            {
                _searchString = value;
                NotifyPropertyChanged("SearchString");
            }
            
        }
        private ObservableCollection<IGameDetailsModel> _Games = new ObservableCollection<IGameDetailsModel>();
        public ObservableCollection<IGameDetailsModel> Games
        {
            get { return _Games; }
            set { _Games = value; NotifyPropertyChanged("Games"); }
        }

        private ObservableCollection<IPlatformModel> _Platforms = new ObservableCollection<IPlatformModel>();
        public ObservableCollection<IPlatformModel> Platforms
        {
            get { return _Platforms; }
            set { _Platforms = value; NotifyPropertyChanged("Platforms"); }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public AddGamePageViewModel()
        {
             container = new UnityContainer();
            UnityRegister.Register(container);
            GameSource = container.Resolve<ISqlConnectionInjector<IGameDetailsModel>>();
            PlatformSource = container.Resolve<ISqlConnectionInjector<IPlatformModel>>();
           

            DetailsCommand = new RelayCommand(new Action<object>(ShowDetails));
            AddCommand = new RelayCommand(new Action<object>(AddGame));
            SearchCommand = new RelayCommand(new Action<object>(SearchGames));
           
            Platforms = new ObservableCollection<IPlatformModel>(PlatformSource.SelectAll());
            DataContext = this;
            
        }

      
        /// <summary>
        /// INotifyPropertyChanged Methods
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// ICommands
        /// </summary>
        public ICommand DetailsCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand SearchCommand { get; private set; }

        #region methods
        /// <summary>
        /// Opens window with details about picked game.
        /// </summary>
        /// <param name="sender"></param>
        private void ShowDetails(object sender)
        {
            IGameDetailsModel game = sender as IGameDetailsModel;
            if (game == null) return;
            StaticData.Instance.Model = game;
            GameDetails details = new GameDetails();
            details.Show();
        }
        /// <summary>
        /// Add picked game to the database source.
        /// </summary>
        /// <param name="sender"></param>
        private void AddGame(object sender)
        {
            if (!(sender is IGameDetailsModel game)) return;
            GameSource.InsertGame(game);
            MessageBox.Show("Game Added");
            EmptyOutFields();
            //Close this window?
        }
        /// <summary>
        /// Based on chosen title and platform, searches API.
        /// </summary>
        /// <param name="sender"></param>
        private async void SearchGames(object sender)
        {
            var dataReciever = container.Resolve<IDataReciever<GameDetailsModel, string, int>>("GameModelsReciever");
            PlatformModel selectedPlatform = sender as PlatformModel;
            PlatformModel platform = selectedPlatform;
            ObservableCollection<IGameDetailsModel> gameList = new ObservableCollection<IGameDetailsModel>(await dataReciever.GetByValue(SearchString, platform.platformId).ConfigureAwait(false));

            Games = gameList;
        }

        public void EmptyOutFields()
        {
            Games = null;
            SearchString = "Insert Game Title";
        }
        #endregion

    }
}
