

using CommunityToolkit.Mvvm.ComponentModel;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
