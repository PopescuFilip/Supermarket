﻿using Supermarket.Stores;
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

            MainViewModel main = serviceProvider.GetRequiredService<MainViewModel>();

            MainWindow = new MainWindow()
            {
                DataContext = main
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider() 
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<SupermarketDBContextFactory>();
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewModelFactory>();
            services.AddSingleton<IViewModelFactory<AdminOptionsViewModel>, AdminOptionsViewModelFactory>();
            services.AddSingleton<ViewModelFactory>();

            services.AddSingleton<NavigationService>();
            services.AddSingleton<DatabaseService>();
            services.AddSingleton<AuthenticationService>();
            
            services.AddSingleton<MainViewModel>();

            services.AddScoped<NavigationStore>();
            services.AddScoped<LoginViewModel>();

            return services.BuildServiceProvider();
        }
    }

}
