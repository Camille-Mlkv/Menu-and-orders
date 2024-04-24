using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class OrderDetails : ContentPage
{
	public OrderDetails()
	{
		InitializeComponent();
		BindingContext = new OrderDetailsViewModel();
	}
}