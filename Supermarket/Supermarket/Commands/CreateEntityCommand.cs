using Supermarket.Models;
using Supermarket.Services;
using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class CreateEntityCommand<T> : CommandBase where T : Entity
    {
        private readonly CreateEntityViewModel<T> _viewModel;
        private readonly IEntityService<T> _entityService;

        public CreateEntityCommand(CreateEntityViewModel<T> viewModel, IEntityService<T> entityService) 
        {
            _viewModel = viewModel;
            _entityService = entityService;
            _viewModel.PropertyChanged += OnViewModelProperyChanged;
        }
        public override void Execute(object? parameter)
        {
            _entityService.Create(_viewModel.GetObjectFromFields());
        }
        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }
        public override bool CanExecute(object? parameter)
        {
            return _viewModel.AllFieldsCompleted() &&
                   base.CanExecute(parameter);
        }
    }
}
