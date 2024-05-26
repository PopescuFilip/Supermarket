using Supermarket.Stores;
using Supermarket.ViewModels;
using Supermarket.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Supermarket.Services
{
    public enum ViewType
    {
        Login,
        AdminOptions,
        CashierOptions,
        
        ProductListing,
        CategoryListing,
        SupplierListing,
        ReceiptListing,
        StockListing,
        UsersListing,

        CreateProduct,
        CreateCategory,
        CreateSupplier,
        CreateReceipt,
        CreateStock,

        ReadonlyViewProduct,

        ViewProduct,
        ViewCategory,
        ViewSupplier,
        ViewReceipt,
        ViewStock,

        ViewProductsForSupplier,
        ViewPriceForCategory,

        AddReceipt,
        AddReceiptItem,
        SearchProduct,

        ProductSearchByBarcode,
        ProductSearchByName,
        ProductSearchByExpirationDate,
        ProductSearchByCategory,
        ProductSearchBySupplier
    }
    public static class NavigationService
    {
        public static NavigationStore NavigationStore {  get; set; }
        public static IFactory Factory { get; set; }

        public static void Navigate(ViewType viewType)
        {
            NavigationStore.CurrentViewModel = Factory.Create(viewType);
        }
    }
}