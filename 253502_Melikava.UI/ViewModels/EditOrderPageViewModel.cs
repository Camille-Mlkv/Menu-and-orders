using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using _253502_Melikava.Domain.Entities;
using _253502_Melikava.UI.Pages;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.UI.ViewModels
{
    [QueryProperty(nameof(Order), "Order")]
    public partial class EditOrderPageViewModel:INotifyPropertyChanged
    {
        private Order _order;
        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));

                NewOrder = new Order()
                {
                    ClientName = _order.ClientName,
                    PreparationTime = _order.PreparationTime,
                    BirthdayGift = _order.BirthdayGift,
                    Sauce = _order.Sauce,
                    Id = _order.Id,
                    MenuPositionId = _order.MenuPositionId,
                };
            }
        }

        private Order _neworder;
        public Order NewOrder
        {
            get => _neworder;
            set
            {
                _neworder = value;
                OnPropertyChanged(nameof(NewOrder));
            }
        }

        private IMediator _mediator;

        public EditOrderPageViewModel(IMediator mediator)
        {
            _mediator= mediator;
        }

        [RelayCommand]
        async Task EditOrder(Order order)=>await SaveEditedOrder(order);
        private async Task SaveEditedOrder(Order order)
        {
            var updatedOrder = await _mediator.Send(new EditOrderRequest(order.ClientName,order.PreparationTime,order.BirthdayGift,order.Sauce,order.Id));
            if (updatedOrder != null)
            {
                await Shell.Current.DisplayAlert("Notification", "Successfully updated!", "OK");
                await Shell.Current.GoToAsync(state:"///MenuPositionsPage");
                //IDictionary<string, object> parameters = new Dictionary<string, object>()
                //{
                //    { "Order", updatedOrder }
                //};
                //await Shell.Current.GoToAsync(nameof(OrderDetails),parameters);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
