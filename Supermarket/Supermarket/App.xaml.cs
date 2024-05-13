using Supermarket.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.DB;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.ViewModels;
using Supermarket.Views;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

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
            _dBContextFactory = new SupermarketDBContextFactory();
            _navigationStore = new NavigationStore(new LoginViewModel());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            //NavigationStore navigationStore = serviceProvider.GetRequiredService<NavigationStore>();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, _dBContextFactory)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider() 
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<SupermarketDBContextFactory>();
            
            services.AddScoped<NavigationStore>();

            return services.BuildServiceProvider();
        }
    }

}
