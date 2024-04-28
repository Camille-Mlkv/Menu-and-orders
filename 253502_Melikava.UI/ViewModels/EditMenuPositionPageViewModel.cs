using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.UI.ViewModels
{
    [QueryProperty(nameof(MenuPosition), "MenuPosition")]
    public partial class EditMenuPositionPageViewModel : INotifyPropertyChanged
    {
        private readonly IMediator _mediator;

        private MenuPosition _menuPosition = new MenuPosition();
        public MenuPosition MenuPosition
        {
            get => _menuPosition;
            set
            {
                _menuPosition = value;
                OnPropertyChanged(nameof(MenuPosition));

                NewMenuPosition = new MenuPosition
                {
                    Id = _menuPosition.Id,
                    Type = _menuPosition.Type,
                    Name = _menuPosition.Name,
                    Price = _menuPosition.Price
                };
            }
        }

        private MenuPosition _newmenuPosition = new MenuPosition();
        public MenuPosition NewMenuPosition
        {
            get => _newmenuPosition;
            set
            {
                _newmenuPosition = value;
                OnPropertyChanged(nameof(NewMenuPosition));
            }
        }

        public EditMenuPositionPageViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        async Task SaveEditedMenuPosition(MenuPosition menuPosition) => await EditMenuPosition(menuPosition);

        public async Task EditMenuPosition(MenuPosition menuPosition)
        {
            var updatedMenuPosition = await _mediator.Send(new EditMenuPositionRequest(menuPosition.Type, menuPosition.Name, menuPosition.Price,menuPosition.Id));
            if (updatedMenuPosition != null)
            {
                await Shell.Current.DisplayAlert("Notification", "Successfully updated!", "OK");
                await Shell.Current.GoToAsync(state: "//MenuPositionsPage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
