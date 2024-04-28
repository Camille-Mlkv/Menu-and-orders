using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;

namespace _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Commands
{
    public class EditMenuPositionRequestHandler : IRequestHandler<EditMenuPositionRequest, MenuPosition>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditMenuPositionRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<MenuPosition> Handle(EditMenuPositionRequest request, CancellationToken cancellationToken)
        {
            var existingMenuPosition = await _unitOfWork.MenuPositionRepository.GetByIdAsync(request.id, cancellationToken);

            if (existingMenuPosition == null)
            {
                throw new InvalidOperationException("The specified menu position could not be found.");
            }

            existingMenuPosition.Type = request.type;
            existingMenuPosition.Name = request.name;
            existingMenuPosition.Price = request.price;

            await _unitOfWork.MenuPositionRepository.UpdateAsync(existingMenuPosition, cancellationToken);

            return existingMenuPosition;
        }
    }
}
