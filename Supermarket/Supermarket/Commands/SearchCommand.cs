using Supermarket.Models;
using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.Commands
{
    public class SearchCommand : CommandBase
    {
        private readonly SearchProductViewModel _viewModel;
        private readonly IEnumerable<Stock> _stocks;
        public SearchCommand(SearchProductViewModel viewModel, IEntityService<Stock> entityService)
        {
            _viewModel = viewModel;
            _stocks = GetAllBuyable(entityService);
        }
        public override void Execute(object? parameter)
        {
            IEnumerable<Stock> currentStocks = _stocks;
            if(!String.IsNullOrEmpty(_viewModel.Barcode))
                 currentStocks = FilterByBarcode(currentStocks);
            if (!String.IsNullOrEmpty(_viewModel.Name))
                currentStocks = FilterByName(currentStocks);
            if(_viewModel.ExpirationDate != null)
                currentStocks = FilterByDate(currentStocks);
            if(_viewModel.SelectedSupplier != null)
                currentStocks = FilterBySupplier(currentStocks);
            if (_viewModel.SelectedCategory!= null)
                currentStocks = FilterByCategory(currentStocks);

            MessageBox.Show($"{currentStocks.Count()} stocks remain");
            //_viewModel.SearchNavigationCommand.Execute(null);
        }
        private IEnumerable<Stock> FilterByBarcode(IEnumerable<Stock> currentStocks)
        {
            return currentStocks.Where(s => s.Product.Barcode.Contains(_viewModel.Barcode));
        }
        private IEnumerable<Stock> FilterByName(IEnumerable<Stock> currentStocks)
        {
            return currentStocks.Where(s => s.Product.Name.Contains(_viewModel.Name));
        }
        private IEnumerable<Stock> FilterBySupplier(IEnumerable<Stock> currentStocks)
        {
            return currentStocks.Where(s => s.Product.Supplier.Id == _viewModel.SelectedSupplier.Id);
            //currentStocks = stocks;
            //currentStocks = currentStocks.Where(s => s.Product.Supplier.Id == _viewModel.SelectedSupplier.Id);
        }
        private IEnumerable<Stock> FilterByCategory(IEnumerable<Stock> currentStocks)
        {
            return currentStocks.Where(s => s.Product.Category.Id == _viewModel.SelectedCategory.Id);
        }
        private IEnumerable<Stock> FilterByDate(IEnumerable<Stock> currentStocks)
        {
            return currentStocks.Where(s => s.ExpirationDate == DateOnly.FromDateTime(_viewModel.ExpirationDate.Value));
        }
        private IEnumerable<Stock> GetAllBuyable(IEntityService<Stock> entityService)
        {
            Dictionary<int, Stock> dictionary = new Dictionary<int, Stock>();
            foreach (var item in entityService.GetAll())
            {
                if (!dictionary.ContainsKey(item.Id))
                {
                    dictionary.Add(item.Id, item);
                    continue;
                }
                if (dictionary[item.Id].ExpirationDate.CompareTo(item.ExpirationDate) < 0)
                    continue;

                dictionary[item.Id] = item;
            }
            return dictionary.Values;
        }
    }
}
