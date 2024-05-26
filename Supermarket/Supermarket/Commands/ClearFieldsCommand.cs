using Supermarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Commands
{
    public class ClearFieldsCommand : CommandBase
    {
        private readonly SearchProductViewModel _viewModel;

        public ClearFieldsCommand(SearchProductViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.SelectedCategory = null;
            _viewModel.SelectedSupplier = null;
            _viewModel.Barcode = null;
            _viewModel.Name = null;
            _viewModel.ExpirationDate = null;
        }
    }
}
