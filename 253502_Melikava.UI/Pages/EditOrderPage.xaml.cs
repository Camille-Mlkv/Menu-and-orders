using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class EditOrderPage : ContentPage
{
	public EditOrderPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new EditOrderPageViewModel(mediator);
	}
}