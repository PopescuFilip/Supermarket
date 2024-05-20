using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supermarket.ViewModels
{
    public class CreateEntityViewModel<T>: ViewModelBase where T : Entity
    {
        public NavigationCommand RenavigationCommand { get; protected init; }
        public ICommand CreateEntityCommand { get; }
        public CreateEntityViewModel(IEntityService<T> entityService)
        {
            CreateEntityCommand = new CreateEntityCommand<T>(this, entityService);
        }
        public virtual T GetObjectFromFields()
        {
            throw new NotImplementedException();
        }
        public virtual bool AllFieldsCompleted()
        {
            throw new NotImplementedException();
        }
        public virtual void ClearFields() 
        {
            throw new NotImplementedException();
        }
    }
}
