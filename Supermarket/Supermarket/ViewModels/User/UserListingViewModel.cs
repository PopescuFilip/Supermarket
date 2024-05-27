using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class UserListingViewModel : EntityListingViewModel<User>
    {
        public UserListingViewModel(
            EntityStore<User> entityStore,
            IEntityService<User> entityService) :
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ViewUser);
        }
    }
}
