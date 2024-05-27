using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using Supermarket.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.ViewModels
{
    public class UserViewModelFactory : IViewModelFactory<UserViewModel>
    {
        private readonly EntityStore<User> _entityStore;
        private readonly IEntityService<User> _entityService;

        public UserViewModelFactory(
            EntityStore<User> entityStore,
            IEntityService<User> entityService) 
        {
            _entityStore = entityStore;
            _entityService = entityService;
        }
        public UserViewModel CreateViewModel()
        {
            return new UserViewModel(_entityStore, _entityService);
        }
    }
}
