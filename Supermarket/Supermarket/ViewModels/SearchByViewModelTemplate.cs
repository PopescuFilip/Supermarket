using Microsoft.EntityFrameworkCore.ChangeTracking;
using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class SearchByViewModelTemplate<T> : ViewModelBase
    {
        private readonly IEntityService<Stock> _stockService;
        private readonly EntityStore<Stock> _entityStore;
        protected readonly IEnumerable<Stock> _allBuyable;
        public ObservableCollection<Stock> FilteredStocks { get; }
		private Stock _selectedStock;
		public Stock SelectedStock
		{
			get { return _selectedStock; }
			set { _selectedStock = value; ViewStock(); }
		}


		private T _filter;
        public T Filter
		{
			get { return _filter; }
			set { _filter = value; SetFilteredStocks(); }
		}

		public NavigationCommand ProductViewNavigationCommand { get; }
		public SearchByViewModelTemplate(IEntityService<Stock> stockService, EntityStore<Stock> entityStore)
		{
            _stockService = stockService;
            _entityStore = entityStore;
            _allBuyable = GetAllBuyable();
            ProductViewNavigationCommand = new NavigationCommand(ViewType.ReadonlyViewStock);
        }
		protected virtual void SetFilteredStocks()
		{
			throw new NotImplementedException();
		}
		private void ViewStock()
		{
			if (_selectedStock == null)
				return;
			_entityStore.Entity = _selectedStock;
			ProductViewNavigationCommand.Execute(null);
		}
        private IEnumerable<Stock> GetAllBuyable()
        {
            Dictionary<int, Stock> dictionary = new Dictionary<int, Stock>();
            foreach (var item in _stockService.GetAll())
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
