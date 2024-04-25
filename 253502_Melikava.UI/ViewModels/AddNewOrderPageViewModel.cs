using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using _253502_Melikava.Domain.Entities;
using _253502_Melikava.UI.Pages;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;


namespace _253502_Melikava.UI.ViewModels
{
    [QueryProperty(nameof(MenuPosition), "MenuPosition")]
    public partial class AddNewOrderPageViewModel : INotifyPropertyChanged
    {
        private readonly IMediator _mediator;
        private Order _newOrder = new Order();
        public Order NewOrder
        {
            get => _newOrder;
            set {
                _newOrder = value;
                OnPropertyChanged(nameof(NewOrder));

            }
        }

        private MenuPosition _menuPosition=new MenuPosition();
        public MenuPosition MenuPosition
        {
            get => _menuPosition;
            set
            {
                _menuPosition = value;
                if (_menuPosition != null)
                {
                    NewOrder.MenuPositionId = _menuPosition.Id;
                }
                
            }
        }


        public AddNewOrderPageViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        async Task SaveNewOrder(Order order) => await AddOrder(order);

        public async Task AddOrder(Order newOrder)
        {
            var addedOrder =await _mediator.Send(new AddOrderRequest(newOrder.ClientName, newOrder.PreparationTime, newOrder.BirthdayGift, newOrder.Sauce, (int)newOrder.MenuPositionId));
            if (addedOrder != null)
            {
                await Shell.Current.DisplayAlert("Notification", "Successfully added!", "OK");
                await Shell.Current.GoToAsync(state: "///MenuPositionsPage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
