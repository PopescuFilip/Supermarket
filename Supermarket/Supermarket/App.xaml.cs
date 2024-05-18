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
using Supermarket.ViewModels.Factories;
using System;

namespace Supermarket
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            NavigationService<LoginViewModel> navigation = serviceProvider.GetRequiredService<NavigationService<LoginViewModel>>();
            navigation.Navigate();

            MainWindow = serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider() 
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(s =>
            {
                return new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                };
            });
            services.AddSingleton<SupermarketDBContextFactory>();
            services.AddSingleton<NavigationStore>();
            
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewModelFactory>();
            services.AddSingleton<IViewModelFactory<AdminOptionsViewModel>, AdminOptionsViewModelFactory>();
            services.AddSingleton<IViewModelFactory<ProductListingViewModel>, ProductsListingViewModelFactory>();
            services.AddSingleton<IViewModelFactory<SupplierListingViewModel>, SupplierListingViewModelFactory>();
            services.AddSingleton<IViewModelFactory<CategoryListingViewModel>, CategoryListingViewModelFactory>();
            //services.AddSingleton<ViewModelFactory>();

            services.AddSingleton<NavigationService<AdminOptionsViewModel>>();
            services.AddSingleton<NavigationService<LoginViewModel>>();
            services.AddSingleton<NavigationService<ProductListingViewModel>>();
            services.AddSingleton<NavigationService<SupplierListingViewModel>>();
            services.AddSingleton<NavigationService<CategoryListingViewModel>>();
            services.AddSingleton<DatabaseService>();
            services.AddSingleton<AuthenticationService>();
            
            services.AddSingleton<MainViewModel>();
            services.AddTransient<LoginViewModel>();


            return services.BuildServiceProvider();
        }
    }

}
