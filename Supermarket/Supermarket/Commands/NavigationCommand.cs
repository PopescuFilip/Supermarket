using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Supermarket.Commands
{
    public class NavigationCommand : CommandBase
    {
        private readonly ViewType _viewType;
        public NavigationCommand(ViewType viewType) 
        {
            _viewType = viewType;
        }

        public override void Execute(object? parameter)
        {
            NavigationService.Navigate(_viewType);
        }
    }
}
