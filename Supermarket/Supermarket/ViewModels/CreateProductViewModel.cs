using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class CreateProductViewModel : CreateEntityViewModel<Product>
    {
        public ObservableCollection<Category> Categories { get; init; }
        public ObservableCollection<Supplier> Suppliers { get; init; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; OnPropertyChanged(nameof(Barcode)); }
        }
        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; OnPropertyChanged(nameof(SelectedCategory)); }
        }
        private Supplier _selectedSupplier;
        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value; OnPropertyChanged(nameof(SelectedSupplier)); }
        }

        public CreateProductViewModel(
            IEntityService<Product> entityService, 
            IEntityService<Category> categoryService,
            IEntityService<Supplier> supplierService) : 
            base(entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.ProductListing);
            Categories = new ObservableCollection<Category>(categoryService.GetAll()); 
            Suppliers = new ObservableCollection<Supplier>(supplierService.GetAll()); 
        }

        public override Product GetObjectFromFields()
        {
            return new Product()
            { 
                Name = Name,
                Barcode = Barcode,
                Category = SelectedCategory,
                Supplier = SelectedSupplier
            };
        }
        public override bool CanCreate()
        {
            if (!IsValidBarcode())
                return false;
            return !String.IsNullOrEmpty(Name) && 
                IsValidBarcode() && 
                SelectedCategory != null &&
                SelectedSupplier != null;
        }
        private bool IsValidBarcode()
        {
            return !String.IsNullOrEmpty(Barcode) && 
                Barcode.Length == 12 && 
                Barcode.All(c => Char.IsDigit(c));
        }
    }
}
