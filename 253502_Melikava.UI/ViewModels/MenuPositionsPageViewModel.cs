using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

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

        //public string ClientName { get; set; }

        // Выбранная позиция меню
        [ObservableProperty]
        MenuPosition selectedMenuPosition;

        // Команда обновления списка позиций меню
        [RelayCommand]
        async Task UpdateGroupList() => await GetMenuPositions();
        // Команда обновления списка заказов позиции меню
        [RelayCommand]
        async Task UpdateMembersList() => await GetOrders();

        public async Task GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersByMenuPositionRequest(SelectedMenuPosition.Id)); 
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Orders.Clear();
                foreach (var order in orders)
                    Orders.Add(order);
            });

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

    }


}
