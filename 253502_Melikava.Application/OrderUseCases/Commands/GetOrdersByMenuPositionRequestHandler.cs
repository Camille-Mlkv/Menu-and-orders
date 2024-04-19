using _253502_Melikava.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.Application.OrderUseCases.Commands
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
            return await _unitOfWork.OrderRepository.ListAsync(order => order.Id.Equals(request.Id), cancellationToken);
        }
    }

}
