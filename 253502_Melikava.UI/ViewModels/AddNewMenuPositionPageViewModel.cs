using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.UI.ViewModels
{
    public partial class AddNewMenuPositionPageViewModel:INotifyPropertyChanged
    {
        private readonly IMediator _mediator;
        private MenuPosition _newMenuPosition = new MenuPosition();
        public MenuPosition NewMenuPosition
        {
            get => _newMenuPosition;
            set
            {
                _newMenuPosition = value;
                OnPropertyChanged(nameof(NewMenuPosition));

            }
        }

        public AddNewMenuPositionPageViewModel(IMediator mediator)
        {
            _mediator= mediator;
        }

        [RelayCommand]
        async Task SaveNewMenuPosition(MenuPosition menuPosition) => await AddMenuPosition(menuPosition);
        public async Task AddMenuPosition(MenuPosition newMenuPosition)
        {
            var addedMenuPosition =  _mediator.Send(new AddMenuPositionRequest(newMenuPosition.Type, newMenuPosition.Name,newMenuPosition.Price));
            await Shell.Current.GoToAsync(state: "//MenuPositionsPage");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
