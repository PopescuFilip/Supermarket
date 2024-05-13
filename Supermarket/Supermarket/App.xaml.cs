using Checkers.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.DB;
using Supermarket.Models;
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
        private readonly SupermarketDBContextFactory _dBContextFactory;
        public App()
        {
            _navigationStore = new NavigationStore(new LoginViewModel());
            _dBContextFactory = new SupermarketDBContextFactory();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
