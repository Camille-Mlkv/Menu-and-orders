using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Commands
{
    public class AddMenuPositionRequestHandler : IRequestHandler<AddMenuPositionRequest, MenuPosition>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddMenuPositionRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<MenuPosition> Handle(AddMenuPositionRequest request, CancellationToken cancellationToken)
        {
            MenuPosition newMenuPosition = new MenuPosition(request.type, request.name, request.price);
            await _unitOfWork.MenuPositionRepository.AddAsync(newMenuPosition,cancellationToken);
            return newMenuPosition;
        }
    }
}
