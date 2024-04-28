using _253502_Melikava.UI.ViewModels;

namespace _253502_Melikava.UI.Pages;

public partial class MenuPositionsPage : ContentPage
{
    private MenuPositionsPageViewModel viewModel;
    public MenuPositionsPage(IMediator mediator)
	{
		InitializeComponent();
        viewModel = new MenuPositionsPageViewModel(mediator);
        BindingContext = viewModel;
    }

    protected override void OnAppearing() //this modification has been done to refrench menu positions' list
    {
        base.OnAppearing();
        var previousSelectedItem = viewModel.SelectedMenuPosition;

        if (BindingContext is MenuPositionsPageViewModel vm)
        {
            if (viewModel.UpdateGroupListCommand.CanExecute(null))
            {
                viewModel.UpdateGroupListCommand.Execute(null);
            }
        }

        if (previousSelectedItem != null)
        {
            viewModel.SelectedMenuPosition = viewModel.MenuPositions.FirstOrDefault(
                item => item.Id == previousSelectedItem.Id
            );
        }
    }
}