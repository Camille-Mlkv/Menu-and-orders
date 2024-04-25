using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.OrderUseCases.Commands
{
    public class AddOrderRequestHandler: IRequestHandler<AddOrderRequest,Order>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            Order newOrder = new Order(request.clientName, request.prepTime, request.birthdayGift, request.sauce);
            newOrder.AddToMenuPosition(request.menuPositionId);
            await _unitOfWork.OrderRepository.AddAsync(newOrder,cancellationToken);
            return newOrder;


        }
    }
}
