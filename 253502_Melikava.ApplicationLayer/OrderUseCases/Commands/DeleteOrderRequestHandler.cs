using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.OrderUseCases.Commands
{
    public class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest,Order>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.OrderRepository.DeleteAsync(request.order, cancellationToken);
            request.order.LeaveMenuPosition();
            return request.order;
        }
    }
}
