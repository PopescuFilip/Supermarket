using Supermarket.Commands;
using Supermarket.Models;
using Supermarket.Services;
using Supermarket.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.ViewModels
{
    public class MostValuableReceiptViewModel : EntityViewModel<Receipt>
    {
        private readonly IEntityService<Receipt> _entityService;
        private readonly IEntityService<ReceiptItem> _receiptItemService;
        public ObservableCollection<ReceiptItem> ReceiptItems { get; private set; }
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set 
            { 
                _selectedDate = value;
                UpdateReceipt();
                OnPropertyChanged(nameof(ReceiptItems));
                OnPropertyChanged(nameof(SelectedDate)); 
            }
        }

        public MostValuableReceiptViewModel(
            EntityStore<Receipt> entityStore, 
            IEntityService<Receipt> entityService,
            IEntityService<ReceiptItem> receiptItemService) : 
            base(entityStore, entityService)
        {
            _entityService = entityService;
            _receiptItemService = receiptItemService;
            
            ReceiptItems = new ObservableCollection<ReceiptItem>();
            RenavigationCommand = new NavigationCommand(ViewType.ReceiptListing);
            SelectedDate = DateTime.Now;
        }
        private void UpdateReceipt()
        {
            //Current = _entityService.GetAll().Max(p => p.Total);
            try
            {
                float max = _entityService
                .GetAll()
                .Where(r => r.Date == DateOnly.FromDateTime(SelectedDate))
                .Max(r => r.Total);

                int id = _entityService
                .GetAll()
                .Where(r => r.Total == max)
                .Select(r => r.Id)
                .First();

                ReceiptItems = new ObservableCollection<ReceiptItem>(
                _receiptItemService
                .GetAll()
                .Where(r => r.Id == id));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                ReceiptItems.Clear();
            }
        }
    }
}
