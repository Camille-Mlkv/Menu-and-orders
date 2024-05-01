using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class OrderDetails : ContentPage
{
	public OrderDetails(IMediator mediator)
	{
		InitializeComponent();
		BindingContext = new OrderDetailsViewModel(mediator);
	}

    protected override void OnAppearing()
    {
        //BindingContext = new OrderDetailsViewModel();
        base.OnAppearing();
		
    }

    private void OnMoveButtonClicked(object sender, EventArgs e)
    {
        GroupPicker.IsVisible = true;
    }

}