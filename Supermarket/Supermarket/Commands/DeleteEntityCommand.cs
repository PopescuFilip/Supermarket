﻿using Supermarket.Models;
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
    public class DeleteEntityCommand<T> : CommandBase where T : Entity
    {
        private readonly EntityViewModel<T> _entityViewModel;
        private readonly IEntityService<T> _entityService;

        public DeleteEntityCommand(EntityViewModel<T> entityViewModel, IEntityService<T> entityService)
        {
            _entityViewModel = entityViewModel;
            _entityService = entityService;
            _entityViewModel.PropertyChanged += OnViewModelProperyChanged;
        }

        public override void Execute(object? parameter)
        {
            _entityService.Delete(_entityViewModel.Entity);
            _entityViewModel.RenavigationCommand.Execute(null);
        }

        private void OnViewModelProperyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

        public override bool CanExecute(object? parameter)
        {
            return _entityViewModel.CanBeDeleted() &&
                   base.CanExecute(parameter);
        }
    }
}
