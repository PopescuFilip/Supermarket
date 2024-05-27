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
    public class UserViewModel : EntityViewModel<User>
    {
        public string Name => _entity.Name;
        public string Password => _entity.Password;
        public string Type => User.ToString(_entity.UserType);
        public NavigationCommand ViewReceiptsNavigationCommand { get; }
        public ICommand ViewReceiptsCommand { get; }
        public UserViewModel(EntityStore<User> entityStore, IEntityService<User> entityService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.UsersListing);
            ViewReceiptsNavigationCommand = new NavigationCommand(ViewType.ViewReceiptsForUser);
            ViewReceiptsCommand = new ViewReceiptsCommand(this, entityStore);
        }
    }
}
