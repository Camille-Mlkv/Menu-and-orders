using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class AddNewMenuPositionPage : ContentPage
{
	public AddNewMenuPositionPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new AddNewMenuPositionPageViewModel(mediator);
	}
}