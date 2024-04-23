using _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.MenuPositionUseCases.Commands
{
    public class GetAllMenuPositionsRequestHandler : IRequestHandler<GetAllMenuPositionsRequest, IEnumerable<MenuPosition>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMenuPositionsRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MenuPosition>> Handle(GetAllMenuPositionsRequest request, CancellationToken cancellationToken)
        {
            var menuPositions = await _unitOfWork.MenuPositionRepository.ListAllAsync(cancellationToken);
            return menuPositions;
        }
    }
}
