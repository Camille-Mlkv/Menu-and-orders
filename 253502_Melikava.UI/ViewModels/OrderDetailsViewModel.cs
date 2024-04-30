﻿

using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using _253502_Melikava.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace _253502_Melikava.UI.ViewModels
{
    [QueryProperty(nameof(Order), "Order")]
    public partial class OrderDetailsViewModel:ObservableObject //INotifyPropertyChanged
    {
        private readonly IMediator _mediator;
        private Order _order;
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        public OrderDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        //------------------------------------------------------
        [ObservableProperty]
        MenuPosition selectedMenuPosition;
        public ObservableCollection<MenuPosition> MenuPositions { get; set; } = new();
        [RelayCommand]
        async Task UpdateGroupList() => await GetMenuPositions();
        public async Task GetMenuPositions()
        {
            var menuPositions = await _mediator.Send(new GetAllMenuPositionsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                MenuPositions.Clear();
                foreach (var position in menuPositions.Where(p=>p.Id!=Order.MenuPositionId))
                    MenuPositions.Add(position);
            });
        }

        [RelayCommand]
        async Task MoveToSelectedMenuPosition() => await DeleteAddOrder();

        public async Task DeleteAddOrder()
        {
            var addedOrder = await _mediator.Send(new AddOrderRequest(Order.ClientName, Order.PreparationTime, Order.BirthdayGift, Order.Sauce, SelectedMenuPosition.Id));
            var deletedOrder = await _mediator.Send(new DeleteOrderRequest(Order));
            if (deletedOrder != null && addedOrder!=null)
            {
                await Shell.Current.DisplayAlert("Notification", $"Successfully moved to {SelectedMenuPosition.Name}!", "OK");
                await Shell.Current.GoToAsync(state: "///MenuPositionsPage");
            }
        }
        //----------------------------------------------------------------

        [RelayCommand]
        async void EditOrder(Order order) => await GoToEditOrderPage(order);

        private async Task GoToEditOrderPage(Order order)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Order", order }
            };

            await Shell.Current.GoToAsync(nameof(EditOrderPage), parameters);
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
