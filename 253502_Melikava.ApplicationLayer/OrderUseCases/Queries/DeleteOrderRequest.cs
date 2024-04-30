using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253502_Melikava.ApplicationLayer.OrderUseCases.Queries
{
    public sealed record DeleteOrderRequest(Order order) : IRequest<Order>
    {
    }
}
