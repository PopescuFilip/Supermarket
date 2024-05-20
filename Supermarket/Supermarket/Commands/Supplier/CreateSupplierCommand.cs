using Supermarket.Models;
using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class CreateSupplierCommand : CommandBase
    {
        private CreateSupplierViewModel _viewModel;
        private IEntityService<Supplier> _supplierService;
        public CreateSupplierCommand(CreateSupplierViewModel createSupplierViewModel, IEntityService<Supplier> supplierService)
        {
            _viewModel = createSupplierViewModel;
            _supplierService = supplierService;
            _viewModel.PropertyChanged += OnViewModelProperyChanged;
        }

        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CreateSupplierViewModel.Name) &&
                e.PropertyName == nameof(CreateSupplierViewModel.CountryOfOrigin))
            {
                OnCanExecutedChanged();
            }
        }
        public override void Execute(object? parameter)
        {
            _supplierService.Create(new Supplier() 
            { 
                Name = _viewModel.Name, 
                CountryOfOrigin = _viewModel.CountryOfOrigin 
            });
            NavigationService.Navigate(ViewType.CategoryListing);
            //MessageBox.Show("Category added");
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Name) &&
                !string.IsNullOrEmpty(_viewModel.CountryOfOrigin) &&
                base.CanExecute(parameter);
        }
    }
}
