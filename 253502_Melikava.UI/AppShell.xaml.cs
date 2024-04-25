using _253502_Melikava.UI.Pages;

namespace _253502_Melikava.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(OrderDetails), typeof(OrderDetails));
            Routing.RegisterRoute(nameof(AddNewOrderPage), typeof(AddNewOrderPage));
        }
    }
}