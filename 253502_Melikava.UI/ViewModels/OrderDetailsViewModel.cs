

using _253502_Melikava.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;

namespace _253502_Melikava.UI.ViewModels
{
    [QueryProperty(nameof(Order), "Order")]
    public partial class OrderDetailsViewModel: INotifyPropertyChanged
    {
        private Order _order;

        public OrderDetailsViewModel()
        {

        }

        public Order Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
