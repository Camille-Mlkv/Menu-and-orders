using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class EditMenuPositionPage : ContentPage
{
	public EditMenuPositionPage(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new EditMenuPositionPageViewModel(mediator);
	}
}