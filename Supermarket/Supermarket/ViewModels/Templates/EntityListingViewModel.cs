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
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class EntityListingViewModel<T> : ViewModelBase where T : Entity
    {
        private readonly EntityStore<T> _entityStore;
        public ObservableCollection<T> Entities { get; protected init; }
        private T? _selectedEntity;
        public T? SelectedEntity
        {
            get { return _selectedEntity; }
            set { _selectedEntity = value; ViewEntity(); }
        }
        public NavigationCommand RenavigationCommand { get; protected init; }
        public NavigationCommand ViewEntityNavigationCommand {  get; protected init; }
        public NavigationCommand CreateEntityNavigationCommand { get; protected init; }
        public EntityListingViewModel(EntityStore<T> entityStore, IEntityService<T> entityService)
        {
            _entityStore = entityStore;
            Entities = new ObservableCollection<T>(entityService.GetAll());
        }
        private void ViewEntity()
        {
            if (SelectedEntity == null)
                return;
            _entityStore.Entity = SelectedEntity;
            ViewEntityNavigationCommand.Execute(null);
            //NavigationService.Navigate(ViewType.ViewCategory);
        }
    }
}
