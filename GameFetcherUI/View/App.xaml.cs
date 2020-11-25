using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using System.IO;
using System.Text;
using Unity;
using GameFetcherUI.ViewModel;

namespace GameFetcherUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private void Application_Startup(object sender, StartupEventArgs e)
		{
            
            
		}
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IView, Main>();
            container.RegisterType<IView, MainViewModel>();
            container.Resolve<Main>().Show();
        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
