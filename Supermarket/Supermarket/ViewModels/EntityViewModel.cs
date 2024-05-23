using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class EntityViewModel<T> : ViewModelBase where T : Entity
    {
        protected T _entity;
        public T Entity => _entity;
        public int Id => _entity.Id;
        public NavigationCommand RenavigationCommand { get; protected init; }
        public ICommand UpdateEntityCommand { get; }
        public ICommand DeleteEntityCommand { get; }
        public EntityViewModel(EntityStore<T> entityStore, IEntityService<T> entityService)
        {
            _entity = entityStore.Entity;
            UpdateEntityCommand = new UpdateEntityCommand<T>(this, entityService);
            DeleteEntityCommand = new DeleteEntityCommand<T>(this, entityService);
        }
        public virtual bool AllFieldsCompleted()
        {
            return true;
        }
        public virtual bool CanBeUpdated()
        {
            return AllFieldsCompleted();
        }
        public virtual bool CanBeDeleted()
        {
            return true;
        }
    }
}
