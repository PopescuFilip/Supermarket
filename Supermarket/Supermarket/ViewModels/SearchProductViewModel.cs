using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class SearchProductViewModel : ViewModelBase
    {
        public ObservableCollection<Category> Categories { get; init; }
        public ObservableCollection<Supplier> Suppliers { get; init; }
        private Category? _selectedCategory;
        public Category? SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; OnPropertyChanged(nameof(SelectedCategory)); }
        }
        private Supplier? _selectedSupplier;
        public Supplier? SelectedSupplier
        {
            get { return _selectedSupplier ; }
            set { _selectedSupplier = value; OnPropertyChanged(nameof(SelectedSupplier)); }
        }
        private string? _barcode;
        public string? Barcode
        {
            get { return _barcode; }
            set { _barcode = value; OnPropertyChanged(nameof(Barcode)); }
        }
        private string? _name;
        public string? Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private DateTime? _expirationDate;
        public DateTime? ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; OnPropertyChanged(nameof(ExpirationDate)); }
        }
        public DateTime Today { get; set; }
        public DateTime TodayPlus10Years { get; set; }
        public NavigationCommand RenavigationCommand { get; }
        public NavigationCommand SearchNavigationCommand { get; }
        public ICommand ClearFieldsCommand { get; }
        public ICommand SearchCommand { get; }
        public SearchProductViewModel(
            IEntityService<Supplier> supplierService, 
            IEntityService<Category> categoryService, 
            IEntityService<Stock> stockService) 
        {
            RenavigationCommand = new NavigationCommand(ViewType.CashierOptions);
            SearchNavigationCommand = new NavigationCommand(ViewType.ReadonlyViewProduct);
            ClearFieldsCommand = new ClearFieldsCommand(this);
            SearchCommand = new SearchCommand(this, stockService);

            Today = DateTime.Now;
            TodayPlus10Years = DateTime.Now.AddYears(10);

            Suppliers = new ObservableCollection<Supplier>(supplierService.GetAll());
            Categories = new ObservableCollection<Category>(categoryService.GetAll());
        }
    }
}
