using _253502_Melikava.ApplicationLayer.OrderUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.OrderUseCases.Commands
{
    public class GetOrdersByMenuPositionRequestHandler : IRequestHandler<GetOrdersByMenuPositionRequest, IEnumerable<Order>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersByMenuPositionRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersByMenuPositionRequest request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.OrderRepository.ListAsync(order => order.MenuPositionId.Equals(request.Id),cancellationToken);
            return orders;
        }
    }

}
