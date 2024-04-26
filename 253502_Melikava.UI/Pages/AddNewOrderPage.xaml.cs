using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class AddNewOrderPage : ContentPage
{
	public AddNewOrderPage(IMediator mediator)
    {
		InitializeComponent();
		BindingContext = new AddNewOrderPageViewModel(mediator);
    }
}