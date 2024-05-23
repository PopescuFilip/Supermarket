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
using System.ServiceProcess;
using Microsoft.Web.WebView2.Core;

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
            
            NavigationService.NavigationStore = serviceProvider.GetRequiredService<NavigationStore>();
            NavigationService.Factory = serviceProvider.GetRequiredService<IFactory>();
            NavigationService.Navigate(ViewType.Login);

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
            services.AddSingleton(typeof(EntityStore<>));
            
            services.AddSingleton<IViewModelFactory<LoginViewModel>, LoginViewModelFactory>();
            services.AddSingleton<IViewModelFactory<AdminOptionsViewModel>, AdminOptionsViewModelFactory>();
            
            services.AddSingleton<IViewModelFactory<ProductListingViewModel>, ProductsListingViewModelFactory>();
            services.AddSingleton<IViewModelFactory<SupplierListingViewModel>, SupplierListingViewModelFactory>();
            services.AddSingleton<IViewModelFactory<CategoryListingViewModel>, CategoryListingViewModelFactory>();
            services.AddSingleton<IViewModelFactory<StockListingViewModel>, StockListingViewModelFactory>();
            
            services.AddSingleton<IViewModelFactory<CreateProductViewModel>, CreateProductViewModelFactory>();
            services.AddSingleton<IViewModelFactory<ProductViewModel>, ProductViewModelFactory>();

            services.AddSingleton<IViewModelFactory<CreateCategoryViewModel>, CreateCategoryViewModelFactory>();
            services.AddSingleton<IViewModelFactory<CategoryViewModel>, CategoryViewModelFactory>();

            services.AddSingleton<IViewModelFactory<CreateSupplierViewModel>, CreateSupplierViewModelFactory>();
            services.AddSingleton<IViewModelFactory<SupplierViewModel>, SupplierViewModelFactory>();

            services.AddSingleton<IViewModelFactory<CreateStockViewModel>, CreateStockViewModelFactory>();
            services.AddSingleton<IViewModelFactory<StockViewModel>, StockViewModelFactory>();

            services.AddSingleton<IFactory, ViewModelFactory>();

            services.AddSingleton<UserService>();
            services.AddSingleton<AuthenticationService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<IEntityService<Category>, CategoryService>();
            services.AddSingleton<IEntityService<Supplier>, SupplierService>();
            services.AddSingleton<IEntityService<Product>, ProductService>();
            services.AddSingleton<IEntityService<Stock>, StockService>();
            services.AddSingleton<IEntityService<Receipt>, EntityService<Receipt>>();
            services.AddSingleton<IEntityService<ReceiptItem>, EntityService<ReceiptItem>>();

            services.AddSingleton(typeof(IEntityService<>), typeof(DeleteableEntityService<>));

            services.AddSingleton<MainViewModel>();
            services.AddTransient<LoginViewModel>();


            return services.BuildServiceProvider();
        }
    }

}
