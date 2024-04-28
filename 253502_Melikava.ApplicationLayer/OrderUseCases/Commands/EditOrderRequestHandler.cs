using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.OrderUseCases.Commands
{
    public class EditOrderRequestHandler : IRequestHandler<EditOrderRequest, Order>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> Handle(EditOrderRequest request, CancellationToken cancellationToken)
        {
            var existingOrder = await _unitOfWork.OrderRepository.GetByIdAsync(request.id, cancellationToken);

            if (existingOrder == null)
            {
                throw new InvalidOperationException("The specified menu position could not be found.");
            }

            existingOrder.ClientName = request.clientName;
            existingOrder.PreparationTime = request.prepTime;
            existingOrder.BirthdayGift= request.birthdayGift;
            existingOrder.Sauce= request.sauce;

            await _unitOfWork.OrderRepository.UpdateAsync(existingOrder, cancellationToken);

            return existingOrder;
        }
    }
}
