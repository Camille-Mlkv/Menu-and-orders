using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using _253502_Melikava.UI.Pages;

namespace _253502_Melikava.UI.ViewModels
{
    public partial class MenuPositionsPageViewModel:ObservableObject
    {
        private readonly IMediator _mediator;
        public MenuPositionsPageViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<MenuPosition> MenuPositions { get; set; } = new();
        public ObservableCollection<Order> Orders { get; set; } = new ();

        // Выбранная позиция меню
        [ObservableProperty]
        MenuPosition selectedMenuPosition;

        // Команда обновления списка позиций меню
        [RelayCommand]
        async Task UpdateGroupList() => await GetMenuPositions();
        // Команда обновления списка заказов позиции меню
        [RelayCommand]
        async Task UpdateMembersList() => await GetOrders();

        [RelayCommand]
        async void ShowDetails(Order order) => await GotoDetailsPage(order);

        [RelayCommand]
        async void AddNewOrder(MenuPosition menuPosition) => await GoToAddNewOrderPage(menuPosition);

        [RelayCommand]
        async void AddNewMenuPosition() => await GoToAddNewMenuPositionPage();


        public async Task GetOrders()
        {
            if (SelectedMenuPosition != null)
            {
                var orders = await _mediator.Send(new GetOrdersByMenuPositionRequest(SelectedMenuPosition.Id));
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Orders.Clear();
                    foreach (var order in orders)
                        Orders.Add(order);
                });
            }
            //else//here
            //{
            //    Orders.Clear();
            //}

        }

        public async Task GetMenuPositions()
        {
            var menuPositions = await _mediator.Send(new GetAllMenuPositionsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                MenuPositions.Clear();
                foreach (var position in menuPositions)
                    MenuPositions.Add(position);
            });
        }

        private async Task GotoDetailsPage(Order Order)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Order", Order }
            };

            await Shell.Current.GoToAsync(nameof(OrderDetails),parameters);
        }

        private async Task GoToAddNewOrderPage(MenuPosition menuPosition)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "MenuPosition", menuPosition }
            };
            if(menuPosition != null)
            {
                await Shell.Current.GoToAsync(nameof(AddNewOrderPage), parameters);
            }
            else
            {
                await Shell.Current.DisplayAlert("Warning", "You haven't selected menu position", "OK");
            }

        }

        private async Task GoToAddNewMenuPositionPage()
        {
            await Shell.Current.GoToAsync(nameof(AddNewMenuPositionPage));
        }
    }


}
