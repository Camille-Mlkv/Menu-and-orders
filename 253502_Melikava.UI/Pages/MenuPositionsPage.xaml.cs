using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class MenuPositionsPage : ContentPage
{
    public MenuPositionsPage(IMediator mediator)
	{
		InitializeComponent();
        BindingContext = new MenuPositionsPageViewModel(mediator);
    }
}