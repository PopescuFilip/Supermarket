﻿using Supermarket.Commands;
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
    public class StockListingViewModel : EntityListingViewModel<Stock>
    {
        public StockListingViewModel(EntityStore<Stock> entityStore, IEntityService<Stock> entityService) : 
            base(entityStore, entityService)
        {
            RenavigationCommand = new NavigationCommand(ViewType.AdminOptions);
            CreateEntityNavigationCommand = new NavigationCommand(ViewType.CreateStock);
            ViewEntityNavigationCommand = new NavigationCommand(ViewType.ViewStock);
        }
    }
}
