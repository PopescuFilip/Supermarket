using Checkers.Stores;
using Supermarket.ViewModels;
using Supermarket.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Supermarket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore(new LoginViewModel());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //_navigationStore.CurrentViewModel = new LoginViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
